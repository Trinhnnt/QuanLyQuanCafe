USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyQuanCafe')
BEGIN
    -- Ngắt kết nối tất cả người dùng đang kết nối đến cơ sở dữ liệu
    ALTER DATABASE QuanLyQuanCafe SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    -- Xóa cơ sở dữ liệu
    DROP DATABASE QuanLyQuanCafe
END
GO

-- Tạo cơ sở dữ liệu
CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

--------------------------------------------------
-- 1. BẢNG NGƯỜI DÙNG VÀ PHÂN QUYỀN
--------------------------------------------------

-- Bảng loại tài khoản
CREATE TABLE AccountType
(
    id INT PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    description NVARCHAR(200) NULL
);
GO

-- Bảng tài khoản người dùng
CREATE TABLE Account
(
    UserName NVARCHAR(100) PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
    Type INT NOT NULL DEFAULT 0,
	Status INT NOT NULL DEFAULT 1, -- 1: Đang làm, 0: Đã nghỉ
    CONSTRAINT FK_Account_AccountType FOREIGN KEY (Type) REFERENCES AccountType(id)
);
GO

-- Bảng nhật ký hoạt động
CREATE TABLE ActivityLog
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId NVARCHAR(100) NULL,
    Action NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    EntityName NVARCHAR(100) NULL,
    EntityId NVARCHAR(50) NULL,
    LogTime DATETIME NOT NULL DEFAULT GETDATE(),
    IPAddress NVARCHAR(50) NULL,
    UserAgent NVARCHAR(500) NULL,
    CONSTRAINT FK_ActivityLog_Account FOREIGN KEY (UserId) REFERENCES Account(UserName)
);
GO

-- Index cho bảng ActivityLog
CREATE INDEX IX_ActivityLog_UserId ON ActivityLog(UserId);
CREATE INDEX IX_ActivityLog_LogTime ON ActivityLog(LogTime);
CREATE INDEX IX_ActivityLog_Action ON ActivityLog(Action);
GO

--------------------------------------------------
-- 2. BẢNG QUẢN LÝ BÀN VÀ KHU VỰC
--------------------------------------------------

-- Bảng bàn ăn
CREATE TABLE TableFood
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên bàn',
    status NVARCHAR(100) NOT NULL DEFAULT N'Trống',
    isActive BIT DEFAULT 1
);
GO

--------------------------------------------------
-- 3. BẢNG QUẢN LÝ THỰC ĐƠN
--------------------------------------------------

-- Bảng danh mục thức ăn
CREATE TABLE FoodCategory
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
);
GO

-- Bảng thức ăn
CREATE TABLE Food
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) DEFAULT N'Chưa đặt tên',
    idCategory INT NOT NULL,
    price FLOAT NOT NULL DEFAULT 0,
    isDeleted BIT DEFAULT 0, -- Thêm trường isDeleted
    FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
);
GO

--------------------------------------------------
-- 4. BẢNG QUẢN LÝ HÓA ĐƠN
--------------------------------------------------

-- Bảng hóa đơn
CREATE TABLE Bill
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE NULL,
    idTable INT NOT NULL,
    status INT NOT NULL DEFAULT 0, -- 0: Chưa thanh toán, 1: Đã thanh toán
    discount INT DEFAULT 0,
    totalPrice DECIMAL(12, 0) DEFAULT 0,
    FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id),

);
GO

-- Bảng chi tiết hóa đơn - Thêm trường price
CREATE TABLE BillInfo
(
    id INT IDENTITY PRIMARY KEY,
    idBill INT NOT NULL,
    idFood INT NOT NULL,
    count INT NOT NULL DEFAULT 0,
    price DECIMAL(12, 0) DEFAULT 0, -- Thêm trường price để lưu giá tại thời điểm đặt hàng
    FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
    FOREIGN KEY (idFood) REFERENCES dbo.Food(id) ON DELETE NO ACTION -- Thay đổi ràng buộc để không xóa BillInfo khi xóa Food
);
GO

--------------------------------------------------
-- 5. STORED PROCEDURES: QUẢN LÝ TÀI KHOẢN
--------------------------------------------------

-- Lấy thông tin tài khoản theo tên đăng nhập
CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
    SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

-- Đăng nhập hệ thống
CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
    SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord AND Status = 1
END
GO

-- Cập nhật thông tin tài khoản
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), 
@displayName NVARCHAR(100), 
@password NVARCHAR(100), 
@newPassword NVARCHAR(100)
AS
BEGIN
    -- Kiểm tra tài khoản có đang hoạt động không
    IF NOT EXISTS (SELECT * FROM dbo.Account WHERE UserName = @userName AND Status = 1)
    BEGIN
        RETURN 0
    END

    DECLARE @isRightPass INT = 0
    
    SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
    
    IF (@isRightPass = 1)
    BEGIN
        IF (@newPassword = NULL OR @newPassword = '')
        BEGIN
            UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
        END
        ELSE
            UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
    END
END
GO

-- Lấy danh sách loại tài khoản
CREATE PROC USP_GetAccountTypes
AS
BEGIN
    SELECT * FROM AccountType;
END
GO

-- Thêm nhật ký hoạt động
CREATE PROC USP_InsertActivityLog
    @userId NVARCHAR(100),
    @action NVARCHAR(100),
    @description NVARCHAR(500),
    @entityName NVARCHAR(100) = NULL,
    @entityId NVARCHAR(50) = NULL,
    @ipAddress NVARCHAR(50) = NULL,
    @userAgent NVARCHAR(500) = NULL
AS
BEGIN
    INSERT INTO ActivityLog (UserId, Action, Description, EntityName, EntityId, LogTime, IPAddress, UserAgent)
    VALUES (@userId, @action, @description, @entityName, @entityId, GETDATE(), @ipAddress, @userAgent)
END
GO

--------------------------------------------------
-- 6. STORED PROCEDURES: QUẢN LÝ BÀN
--------------------------------------------------

-- Lấy danh sách bàn đang hoạt động
CREATE PROC USP_GetTableList
AS
    SELECT * FROM dbo.TableFood WHERE isActive = 1
GO

-- Chuyển bàn
CREATE PROC USP_SwitchTable
@idTable1 INT, @idTable2 INT
AS
BEGIN
    DECLARE @idFirstBill INT
    DECLARE @idSecondBill INT

    DECLARE @idFirstTableEmpty INT = 1
    DECLARE @idSecondTableEmpty INT = 1

    SELECT @idSecondBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
    SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0 

    IF (@idFirstBill IS NULL)
    BEGIN
        INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status, discount)
        VALUES (GETDATE(), NULL, @idTable1, 0, 0)
        SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
    END
    SELECT @idFirstTableEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill

    IF (@idSecondBill IS NULL)
    BEGIN
        INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status, discount)
        VALUES (GETDATE(), NULL, @idTable2, 0, 0)
        SELECT @idSecondBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
    END
    SELECT @idSecondTableEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSecondBill

    SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSecondBill
    UPDATE dbo.BillInfo SET idBill = @idSecondBill WHERE idBill = @idFirstBill
    UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
    DROP TABLE IDBillInfoTable
    
    IF (@idFirstTableEmpty = 0)
        UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
    IF (@idSecondTableEmpty = 0)
        UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO

--------------------------------------------------
-- 7. STORED PROCEDURES: QUẢN LÝ HÓA ĐƠN
--------------------------------------------------

-- Tạo hóa đơn mới
CREATE PROC USP_InsertBill
@idTable INT 
AS
BEGIN
    INSERT dbo.Bill (DateCheckIn, DateCheckOut, idTable, status, discount)
    VALUES (GETDATE(), NULL, @idTable, 0, 0)
END
GO

-- Thêm/cập nhật chi tiết hóa đơn - Cập nhật để lưu giá
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
    DECLARE @isExitsBillInfo INT
    DECLARE @foodCount INT = 1
    DECLARE @foodPrice DECIMAL(12, 0) = 0
    
    -- Lấy giá hiện tại của món ăn
    SELECT @foodPrice = price FROM dbo.Food WHERE id = @idFood
    
    SELECT @isExitsBillInfo = id, @foodCount = b.count
    FROM dbo.BillInfo AS b
    WHERE idBill = @idBill AND idFood = @idFood

    IF (@isExitsBillInfo > 0)
    BEGIN
        DECLARE @newCount INT = @foodCount + @count
        IF (@newCount > 0)
            UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood AND idBill = @idBill
        ELSE
            DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
    END
    ELSE 
    BEGIN
        INSERT dbo.BillInfo (idBill, idFood, count, price) 
        VALUES (@idBill, @idFood, @count, @foodPrice)
    END
END
GO

-- Lấy danh sách hóa đơn theo ngày
CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
    SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
    FROM dbo.Bill AS b, dbo.TableFood AS t
    WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
    AND t.id = b.idTable
END
GO

-- Lấy danh sách hóa đơn theo ngày và phân trang
CREATE PROC USP_GetListBillByDateAndPage
@checkIn date, @checkOut date, @page int
AS 
BEGIN
    DECLARE @pageRows INT = 10
    DECLARE @selectRows INT = @pageRows
    DECLARE @exceptRows INT = (@page - 1) * @pageRows
    
    ;WITH BillShow AS( SELECT b.ID, t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
    FROM dbo.Bill AS b,dbo.TableFood AS t
    WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
    AND t.id = b.idTable)
    
    SELECT TOP (@selectRows) * FROM BillShow WHERE id NOT IN (SELECT TOP (@exceptRows) id FROM BillShow)
END
GO

-- Đếm số hóa đơn theo ngày
CREATE PROC USP_GetNumBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
    SELECT COUNT(*)
    FROM dbo.Bill AS b,dbo.TableFood AS t
    WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
    AND t.id = b.idTable
END
GO

-- Thêm hàm lấy tổng tiền từ BillInfo
CREATE PROC USP_GetTotalPrice
@idBill INT,
@discount INT = 0
AS
BEGIN
    DECLARE @totalPrice DECIMAL(12, 0) = 0
    
    -- Tính tổng tiền từ chi tiết hóa đơn
    SELECT @totalPrice = SUM(bi.count * bi.price)
    FROM BillInfo bi
    WHERE bi.idBill = @idBill
    
    -- Áp dụng giảm giá nếu có
    IF (@discount > 0)
    BEGIN
        SET @totalPrice = @totalPrice - (@totalPrice / 100 * @discount)
    END
    
    SELECT ISNULL(@totalPrice, 0) AS TotalPrice
END
GO

-- Thêm hàm thanh toán hóa đơn
CREATE PROC USP_CheckOut
@idBill INT, 
@discount INT, 
@totalPrice DECIMAL(12, 0),
@userName NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Cập nhật hóa đơn
        UPDATE Bill 
        SET 
            DateCheckOut = GETDATE(), 
            status = 1, -- Đã thanh toán
            discount = @discount,
            totalPrice = @totalPrice
        WHERE id = @idBill
        
        -- Ghi log hoạt động
        EXEC USP_InsertActivityLog 
            @userId = @userName,
            @action = N'CHECKOUT',
            @description = N'Thanh toán hóa đơn',
            @entityName = N'Bill',
            @entityId = @idBill
            
        COMMIT TRANSACTION
        SELECT 1 AS Result -- Thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        SELECT 0 AS Result -- Thất bại
    END CATCH
END
GO

-- Lấy hóa đơn chưa thanh toán theo bàn
CREATE PROC USP_GetUncheckBillByTableID
@idTable INT
AS
BEGIN
    SELECT * FROM dbo.Bill WHERE idTable = @idTable AND status = 0
END
GO

-- Lấy ID hóa đơn chưa thanh toán theo bàn
CREATE PROC USP_GetUncheckBillIDByTableID
@idTable INT
AS
BEGIN
    SELECT id FROM dbo.Bill WHERE idTable = @idTable AND status = 0
END
GO

--------------------------------------------------
-- 8. STORED PROCEDURES: BÁO CÁO THỐNG KÊ
--------------------------------------------------

-- Báo cáo doanh thu theo thời gian
CREATE PROC USP_ReportRevenueByTime
    @fromDate DATE,
    @toDate DATE,
    @groupBy NVARCHAR(10) -- 'DAY', 'WEEK', 'MONTH'
AS
BEGIN
    IF @groupBy = 'DAY'
    BEGIN
        SELECT 
            CONVERT(DATE, DateCheckOut) AS TimePoint,
            SUM(totalPrice) AS Revenue,
            COUNT(id) AS BillCount,
            AVG(totalPrice) AS AverageBillValue
        FROM dbo.Bill
        WHERE DateCheckOut BETWEEN @fromDate AND @toDate
            AND status = 1
        GROUP BY CONVERT(DATE, DateCheckOut)
        ORDER BY TimePoint
    END
    ELSE IF @groupBy = 'WEEK'
    BEGIN
        SELECT 
            DATEPART(YEAR, DateCheckOut) AS [Year],
            DATEPART(WEEK, DateCheckOut) AS [Week],
            CONCAT('Week ', DATEPART(WEEK, DateCheckOut), '/', DATEPART(YEAR, DateCheckOut)) AS TimePoint,
            SUM(totalPrice) AS Revenue,
            COUNT(id) AS BillCount,
            AVG(totalPrice) AS AverageBillValue
        FROM dbo.Bill
        WHERE DateCheckOut BETWEEN @fromDate AND @toDate
            AND status = 1
        GROUP BY DATEPART(YEAR, DateCheckOut), DATEPART(WEEK, DateCheckOut)
        ORDER BY [Year], [Week]
    END
    ELSE IF @groupBy = 'MONTH'
    BEGIN
        SELECT 
            DATEPART(YEAR, DateCheckOut) AS [Year],
            DATEPART(MONTH, DateCheckOut) AS [Month],
            CONCAT(CASE DATEPART(MONTH, DateCheckOut)
                WHEN 1 THEN N'Tháng 1'
                WHEN 2 THEN N'Tháng 2'
                WHEN 3 THEN N'Tháng 3'
                WHEN 4 THEN N'Tháng 4'
                WHEN 5 THEN N'Tháng 5'
                WHEN 6 THEN N'Tháng 6'
                WHEN 7 THEN N'Tháng 7'
                WHEN 8 THEN N'Tháng 8'
                WHEN 9 THEN N'Tháng 9'
                WHEN 10 THEN N'Tháng 10'
                WHEN 11 THEN N'Tháng 11'
                WHEN 12 THEN N'Tháng 12'
            END, '/', DATEPART(YEAR, DateCheckOut)) AS TimePoint,
            SUM(totalPrice) AS Revenue,
            COUNT(id) AS BillCount,
            AVG(totalPrice) AS AverageBillValue
        FROM dbo.Bill
        WHERE DateCheckOut BETWEEN @fromDate AND @toDate
            AND status = 1
        GROUP BY DATEPART(YEAR, DateCheckOut), DATEPART(MONTH, DateCheckOut)
        ORDER BY [Year], [Month]
    END
END
GO

-- Báo cáo món ăn bán chạy
CREATE PROC USP_ReportTopSellingFood
    @fromDate DATE,
    @toDate DATE,
    @topCount INT = 10
AS
BEGIN
    SELECT TOP (@topCount)
        f.name AS FoodName,
        fc.name AS CategoryName,
        SUM(bi.count) AS TotalQuantity,
        bi.price AS UnitPrice, -- Sử dụng giá từ BillInfo
        SUM(bi.count * bi.price) AS TotalRevenue
    FROM dbo.BillInfo bi
    JOIN dbo.Bill b ON bi.idBill = b.id
    JOIN dbo.Food f ON bi.idFood = f.id
    JOIN dbo.FoodCategory fc ON f.idCategory = fc.id
    WHERE b.DateCheckOut BETWEEN @fromDate AND @toDate
        AND b.status = 1
        AND f.isDeleted = 0
    GROUP BY f.id, f.name, fc.name, bi.price
    ORDER BY TotalQuantity DESC
END
GO

-- Báo cáo sử dụng bàn
CREATE PROC USP_ReportTableUsage
    @fromDate DATE,
    @toDate DATE
AS
BEGIN
    SELECT 
        t.id AS TableID,
        t.name AS TableName,
        COUNT(b.id) AS BillCount,
        SUM(b.totalPrice) AS TotalRevenue,
        AVG(b.totalPrice) AS AverageRevenue,
        SUM(DATEDIFF(MINUTE, b.DateCheckIn, b.DateCheckOut)) AS TotalMinutesUsed,
        AVG(DATEDIFF(MINUTE, b.DateCheckIn, b.DateCheckOut)) AS AverageMinutesPerBill
    FROM dbo.TableFood t
    LEFT JOIN dbo.Bill b ON t.id = b.idTable
    WHERE (b.DateCheckOut BETWEEN @fromDate AND @toDate OR b.DateCheckOut IS NULL)
        AND (b.status = 1 OR b.status IS NULL)
        AND t.isActive = 1
    GROUP BY t.id, t.name
    ORDER BY TotalRevenue DESC
END
GO

-- Phân tích mối liên hệ giữa các món ăn
CREATE PROCEDURE USP_ReportFoodAssociation
    @fromDate DATE,
    @toDate DATE,
    @minSupport FLOAT = 0.1,
    @minConfidence FLOAT = 0.5
AS
BEGIN
    SET NOCOUNT ON;

    -- Tạo bảng tạm để lưu thông tin các hóa đơn trong khoảng thời gian
    DECLARE @Bills TABLE (BillID INT);
    
    INSERT INTO @Bills (BillID)
    SELECT DISTINCT b.id
    FROM Bill b
    WHERE b.DateCheckIn >= @fromDate AND b.DateCheckOut <= @toDate
          AND b.status = 1; -- Chỉ lấy các hóa đơn đã thanh toán
    
    -- Đếm tổng số hóa đơn
    DECLARE @totalBills INT;
    SELECT @totalBills = COUNT(*) FROM @Bills;
    
    -- Tạo bảng tạm để lưu thông tin về số lần xuất hiện của từng món ăn
    DECLARE @FoodCounts TABLE (
        FoodID INT,
        FoodName NVARCHAR(100),
        FoodCount INT
    );
    
    -- Tính số lần xuất hiện của từng món ăn trong các hóa đơn
    INSERT INTO @FoodCounts (FoodID, FoodName, FoodCount)
    SELECT f.id, f.name, COUNT(DISTINCT bi.idBill)
    FROM Food f
    JOIN BillInfo bi ON f.id = bi.idFood
    JOIN @Bills b ON bi.idBill = b.BillID
    WHERE f.isDeleted = 0
    GROUP BY f.id, f.name;
    
    -- Tạo bảng tạm để lưu thông tin về các cặp món ăn xuất hiện cùng nhau
    DECLARE @FoodPairs TABLE (
        Food1ID INT,
        Food2ID INT,
        PairCount INT
    );
    
    -- Tính số lần xuất hiện cùng nhau của các cặp món ăn
    INSERT INTO @FoodPairs (Food1ID, Food2ID, PairCount)
    SELECT bi1.idFood AS Food1ID, bi2.idFood AS Food2ID, COUNT(DISTINCT bi1.idBill) AS PairCount
    FROM BillInfo bi1
    JOIN BillInfo bi2 ON bi1.idBill = bi2.idBill AND bi1.idFood < bi2.idFood
    JOIN @Bills b ON bi1.idBill = b.BillID
    JOIN Food f1 ON bi1.idFood = f1.id AND f1.isDeleted = 0
    JOIN Food f2 ON bi2.idFood = f2.id AND f2.isDeleted = 0
    GROUP BY bi1.idFood, bi2.idFood;
    
    -- Tạo bảng kết quả
    DECLARE @ResultTable TABLE (
        FoodName1 NVARCHAR(100),
        FoodName2 NVARCHAR(100),
        PairCount INT,
        FoodCount1 INT,
        FoodCount2 INT,
        Support DECIMAL(5,2),
        ConfidenceAB DECIMAL(5,2),
        ConfidenceBA DECIMAL(5,2),
        Lift DECIMAL(5,2)
    );
    
    -- Tính toán các chỉ số và đưa vào bảng kết quả
    INSERT INTO @ResultTable
    SELECT 
        fc1.FoodName AS FoodName1,
        fc2.FoodName AS FoodName2,
        fp.PairCount AS PairCount,
        fc1.FoodCount AS FoodCount1,
        fc2.FoodCount AS FoodCount2,
        CAST(ROUND(CAST(fp.PairCount AS DECIMAL(5,2)) / @totalBills, 2) AS DECIMAL(5,2)) AS Support,
        CAST(ROUND(CAST(fp.PairCount AS DECIMAL(5,2)) / fc1.FoodCount, 2) AS DECIMAL(5,2)) AS ConfidenceAB,
        CAST(ROUND(CAST(fp.PairCount AS DECIMAL(5,2)) / fc2.FoodCount, 2) AS DECIMAL(5,2)) AS ConfidenceBA,
        CAST(ROUND(
            (CAST(fp.PairCount AS DECIMAL(5,2)) / @totalBills) / 
            ((CAST(fc1.FoodCount AS DECIMAL(5,2)) / @totalBills) * (CAST(fc2.FoodCount AS DECIMAL(5,2)) / @totalBills)), 
            2) AS DECIMAL(5,2)) AS Lift
    FROM @FoodPairs fp
    JOIN @FoodCounts fc1 ON fp.Food1ID = fc1.FoodID
    JOIN @FoodCounts fc2 ON fp.Food2ID = fc2.FoodID
    WHERE CAST(fp.PairCount AS DECIMAL(5,2)) / @totalBills >= @minSupport
          AND (CAST(fp.PairCount AS DECIMAL(5,2)) / fc1.FoodCount >= @minConfidence
               OR CAST(fp.PairCount AS DECIMAL(5,2)) / fc2.FoodCount >= @minConfidence);
    
    -- Trả về kết quả
    IF EXISTS (SELECT * FROM @ResultTable)
    BEGIN
        -- Có dữ liệu, trả về kết quả thực tế
        SELECT 
            FoodName1,
            FoodName2,
            PairCount,
            FoodCount1,
            FoodCount2,
            Support,
            ConfidenceAB,
            ConfidenceBA,
            Lift
        FROM @ResultTable
        ORDER BY Support DESC, Lift DESC;
    END
    ELSE
    BEGIN
        -- Không có dữ liệu, trả về cấu trúc cột với một dòng thông báo
        SELECT 
            CAST(N'KhongCoDuLieu' AS NVARCHAR(100)) AS FoodName1,
            CAST(N'KhongCoDuLieu' AS NVARCHAR(100)) AS FoodName2,
            CAST(0 AS INT) AS PairCount,
            CAST(0 AS INT) AS FoodCount1,
            CAST(0 AS INT) AS FoodCount2,
            CAST(0.00 AS DECIMAL(5,2)) AS Support,
            CAST(0.00 AS DECIMAL(5,2)) AS ConfidenceAB,
            CAST(0.00 AS DECIMAL(5,2)) AS ConfidenceBA,
            CAST(0.00 AS DECIMAL(5,2)) AS Lift
        WHERE 1=0;  -- Không trả về dòng này, chỉ lấy cấu trúc
    END
END
GO

--------------------------------------------------
-- 9. TRIGGERS
--------------------------------------------------

-- Cập nhật trạng thái bàn khi thêm/sửa chi tiết hóa đơn
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
    DECLARE @idBill INT
    SELECT @idBill = idBill FROM inserted
    DECLARE @idTable INT
    SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
    UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO

-- Cập nhật trạng thái bàn khi cập nhật hóa đơn
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
    DECLARE @idTable INT
    DECLARE @idBill INT
    
    SELECT @idBill = id, @idTable = idTable FROM inserted
    
    DECLARE @count INT = 0
    SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
    
    IF (@count = 0)
        UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
    ELSE
        UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO

-- Cập nhật trạng thái bàn khi xóa chi tiết hóa đơn
CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
    DECLARE @idBillInfo INT
    DECLARE @idBill INT
    SELECT @idBillInfo = id, @idBill = deleted.idBill FROM deleted
    DECLARE @idTable INT
    SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
    DECLARE @count INT = 0
    SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
    IF (@count = 0)
        UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

-- Trigger để đảm bảo lưu giá hiện tại khi thêm món vào BillInfo
CREATE TRIGGER UTG_InsertBillInfoPrice
ON dbo.BillInfo FOR INSERT
AS
BEGIN
    DECLARE @idFood INT
    DECLARE @idBillInfo INT
    
    SELECT @idBillInfo = id, @idFood = idFood FROM inserted
    
    -- Kiểm tra nếu giá chưa được thiết lập
    IF EXISTS (SELECT * FROM inserted WHERE price = 0)
    BEGIN
        DECLARE @price FLOAT
        SELECT @price = price FROM Food WHERE id = @idFood
        
        -- Cập nhật giá từ bảng Food
        UPDATE BillInfo
        SET price = @price
        WHERE id = @idBillInfo
    END
END
GO

-- Trigger để đánh dấu xóa Food thay vì xóa thật sự
CREATE TRIGGER UTG_DeleteFood
ON dbo.Food INSTEAD OF DELETE
AS
BEGIN
    DECLARE @idFood INT
    SELECT @idFood = id FROM deleted
    
    -- Đánh dấu xóa thay vì xóa thật sự
    UPDATE Food
    SET isDeleted = 1
    WHERE id = @idFood
END
GO
-- Tạo một trigger để đảm bảo không xóa tài khoản mà chỉ đánh dấu là đã nghỉ
CREATE TRIGGER UTG_DeleteAccount
ON dbo.Account INSTEAD OF DELETE
AS
BEGIN
    DECLARE @userName NVARCHAR(100)
    SELECT @userName = UserName FROM deleted
    
    -- Đánh dấu tài khoản đã nghỉ thay vì xóa thật sự
    UPDATE Account
    SET Status = 0
    WHERE UserName = @userName
END
GO
--------------------------------------------------
-- 10. HÀM HỖ TRỢ
--------------------------------------------------

-- Hàm chuyển đổi chuỗi không dấu
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
    IF @strInput IS NULL RETURN @strInput 
    IF @strInput = '' RETURN @strInput 
    
    DECLARE @RT NVARCHAR(4000) 
    DECLARE @SIGN_CHARS NCHAR(136) 
    DECLARE @UNSIGN_CHARS NCHAR (136) 
    
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
    
    DECLARE @COUNTER int 
    DECLARE @COUNTER1 int 
    SET @COUNTER = 1 
    
    WHILE (@COUNTER <=LEN(@strInput)) 
    BEGIN 
        SET @COUNTER1 = 1 
        WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
        BEGIN 
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
            BEGIN 
                IF @COUNTER=1 
                    SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
                ELSE 
                    SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
                BREAK 
            END 
            SET @COUNTER1 = @COUNTER1 +1 
        END 
        SET @COUNTER = @COUNTER +1 
    END 
    SET @strInput = replace(@strInput,' ','-') 
    RETURN @strInput 
END
GO

-- Hàm lấy tổng tiền của hóa đơn
CREATE FUNCTION [dbo].[GetTotalPrice] (@idBill INT)
RETURNS DECIMAL(12, 0)
AS
BEGIN
    DECLARE @totalPrice DECIMAL(12, 0) = 0
    
    -- Tính tổng tiền từ chi tiết hóa đơn sử dụng giá đã lưu
    SELECT @totalPrice = SUM(bi.count * bi.price)
    FROM BillInfo bi
    WHERE bi.idBill = @idBill
    
    RETURN ISNULL(@totalPrice, 0)
END
GO

--------------------------------------------------
-- 11. THÊM DỮ LIỆU MẪU
--------------------------------------------------
USE QuanLyQuanCafe
GO

-- 1. Thêm loại tài khoản
INSERT INTO AccountType (id, name, description) VALUES
(0, N'Nhân viên', N'Tài khoản dành cho nhân viên, có quyền hạn chế'),
(1, N'Quản trị viên', N'Tài khoản dành cho quản lý, có đầy đủ quyền');
GO

-- 2. Thêm tài khoản mẫu
-- Mật khẩu mặc định: 1 (đây chỉ là mẫu, trong thực tế nên mã hóa mật khẩu)
INSERT INTO Account (UserName, DisplayName, PassWord, Type, Status) VALUES
(N'admin', N'Quản trị viên', N'1962026656160185351301320480154111117132155', 1, 1),
(N'staff', N'Nhân viên', N'1962026656160185351301320480154111117132155', 0, 1);
GO

-- 3. Thêm bàn mẫu
DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
    INSERT INTO TableFood (name) VALUES (N'Bàn ' + CAST(@i AS NVARCHAR(10)))
    SET @i = @i + 1
END
GO

-- 4. Thêm danh mục thức uống
INSERT INTO FoodCategory (name) VALUES
(N'Cà phê'),
(N'Trà sữa'),
(N'Sinh tố'),
(N'Nước ép'),
(N'Đá xay'),
(N'Trà');
GO

-- 5. Thêm thức uống
-- Cà phê
INSERT INTO Food (name, idCategory, price) VALUES
(N'Cà phê đen', 1, 20000),
(N'Cà phê sữa', 1, 25000),
(N'Cà phê dừa', 1, 35000),
(N'Bạc xỉu', 1, 30000),
(N'Cà phê trứng', 1, 40000),
(N'Americano', 1, 35000),
(N'Cappuccino', 1, 45000),
(N'Latte', 1, 45000),
(N'Espresso', 1, 30000),
(N'Mocha', 1, 50000);

-- Trà sữa
INSERT INTO Food (name, idCategory, price) VALUES
(N'Trà sữa truyền thống', 2, 30000),
(N'Trà sữa matcha', 2, 35000),
(N'Trà sữa socola', 2, 35000),
(N'Trà sữa trân châu đường đen', 2, 40000),
(N'Trà sữa khoai môn', 2, 35000),
(N'Trà sữa dâu', 2, 35000),
(N'Trà sữa xoài', 2, 35000),
(N'Hồng trà sữa', 2, 30000);

-- Sinh tố
INSERT INTO Food (name, idCategory, price) VALUES
(N'Sinh tố xoài', 3, 35000),
(N'Sinh tố bơ', 3, 40000),
(N'Sinh tố dâu', 3, 35000),
(N'Sinh tố mãng cầu', 3, 40000),
(N'Sinh tố sapoche', 3, 35000),
(N'Sinh tố dừa', 3, 35000),
(N'Sinh tố thanh long', 3, 35000),
(N'Sinh tố dưa hấu', 3, 30000);

-- Nước ép
INSERT INTO Food (name, idCategory, price) VALUES
(N'Nước ép cam', 4, 35000),
(N'Nước ép dưa hấu', 4, 30000),
(N'Nước ép táo', 4, 35000),
(N'Nước ép dứa', 4, 35000),
(N'Nước ép ổi', 4, 35000),
(N'Nước ép cà rốt', 4, 35000),
(N'Nước ép thơm', 4, 35000),
(N'Nước ép lựu', 4, 45000);

-- Đá xay
INSERT INTO Food (name, idCategory, price) VALUES
(N'Chocolate đá xay', 5, 45000),
(N'Matcha đá xay', 5, 45000),
(N'Oreo đá xay', 5, 45000),
(N'Cà phê đá xay', 5, 45000),
(N'Dâu đá xay', 5, 45000),
(N'Việt quất đá xay', 5, 45000),
(N'Xoài đá xay', 5, 45000),
(N'Kiwi đá xay', 5, 45000);

-- Trà
INSERT INTO Food (name, idCategory, price) VALUES
(N'Trà đào', 6, 30000),
(N'Trà vải', 6, 30000),
(N'Trà chanh', 6, 25000),
(N'Trà đen', 6, 25000),
(N'Trà xanh', 6, 25000),
(N'Trà gừng', 6, 30000),
(N'Trà hoa cúc', 6, 30000),
(N'Trà ô long', 6, 30000);
GO

-- 6. Tạo một số hóa đơn mẫu
-- Hóa đơn đã thanh toán
INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
VALUES 
(DATEADD(day, -1, GETDATE()), DATEADD(day, -1, GETDATE()), 1, 1, 0, 80000),
(DATEADD(day, -1, GETDATE()), DATEADD(day, -1, GETDATE()), 2, 1, 10, 90000),
(DATEADD(day, -2, GETDATE()), DATEADD(day, -2, GETDATE()), 3, 1, 0, 120000),
(DATEADD(day, -2, GETDATE()), DATEADD(day, -2, GETDATE()), 5, 1, 5, 150000),
(DATEADD(day, -3, GETDATE()), DATEADD(day, -3, GETDATE()), 7, 1, 0, 95000);

-- Chi tiết hóa đơn đã thanh toán
INSERT INTO BillInfo (idBill, idFood, count, price) VALUES
(1, 1, 2, 20000), -- 2 cà phê đen
(1, 11, 1, 30000), -- 1 trà sữa truyền thống
(2, 2, 2, 25000), -- 2 cà phê sữa
(2, 30, 1, 35000), -- 1 nước ép cam
(3, 19, 2, 35000), -- 2 sinh tố xoài
(3, 37, 1, 45000), -- 1 oreo đá xay
(4, 8, 2, 45000), -- 2 latte
(4, 9, 1, 30000), -- 1 espresso
(4, 41, 1, 30000), -- 1 trà đào
(5, 25, 1, 35000), -- 1 sinh tố sapoche
(5, 33, 1, 35000), -- 1 nước ép ổi
(5, 42, 1, 30000); -- 1 trà vải

-- Hóa đơn chưa thanh toán (bàn có người)
INSERT INTO Bill (DateCheckIn, DateCheckOut, idTable, status, discount, totalPrice)
VALUES 
(GETDATE(), NULL, 10, 0, 0, 0);

-- Chi tiết hóa đơn chưa thanh toán
INSERT INTO BillInfo (idBill, idFood, count, price) VALUES
(6, 7, 1, 45000), -- 1 cappuccino
(6, 12, 1, 35000); -- 1 trà sữa matcha
GO

-- 7. Thêm nhật ký hoạt động mẫu
INSERT INTO ActivityLog (UserId, Action, Description, EntityName, EntityId, LogTime)
VALUES
(N'admin', N'LOGIN', N'Đăng nhập hệ thống', NULL, NULL, DATEADD(hour, -1, GETDATE())),
(N'admin', N'CREATE', N'Thêm món mới', N'Food', N'7', DATEADD(hour, -1, GETDATE())),
(N'staff', N'LOGIN', N'Đăng nhập hệ thống', NULL, NULL, DATEADD(minute, -30, GETDATE())),
(N'staff', N'CREATE', N'Tạo hóa đơn mới', N'Bill', N'6', DATEADD(minute, -25, GETDATE()));
GO

SELECT * FROM dbo.ActivityLog

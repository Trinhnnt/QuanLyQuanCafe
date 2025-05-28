# Quản Lý Quán Cafe

Hệ thống quản lý bán hàng của cửa hàng cafe được xây dựng trên nền tảng Windows Forms với .NET Framework và SQL Server.

## Giới thiệu

Phần mềm quản lý quán cafe là một công cụ hỗ trợ đắc lực cho việc vận hành và quản lý các hoạt động kinh doanh trong quán cafe, đặc biệt là với các quán có quy mô nhỏ và vừa. Với sự phát triển nhanh chóng của ngành dịch vụ ăn uống, nhu cầu quản lý chính xác, nhanh chóng và hiệu quả ngày càng trở nên cấp thiết nhằm nâng cao chất lượng phục vụ và tăng lợi nhuận.

## Tính năng

- **Quản lý thực đơn**: Thêm, sửa, xóa món ăn và danh mục
- **Quản lý bàn**: Theo dõi trạng thái bàn, chuyển bàn
- **Quản lý hóa đơn**: Tạo hóa đơn, thêm món, áp dụng giảm giá, thanh toán
- **Quản lý tài khoản**: Phân quyền người dùng (Admin/Staff), đổi mật khẩu
- **Báo cáo thống kê**: Doanh thu theo thời gian, món ăn bán chạy, những món ăn được mua cùng nhau nhiều lần
- **Ghi log hoạt động**: Lưu lại các thao tác của người dùng

## Kiến trúc hệ thống

Hệ thống được xây dựng theo mô hình kiến trúc 3 lớp:

1. **Lớp giao diện (Presentation Layer - Form)**: Tương tác với người dùng
2. **Lớp truy cập dữ liệu (Data Access Layer - DAO)**: Xử lý logic nghiệp vụ và truy vấn dữ liệu
3. **Lớp đối tượng truyền dữ liệu (Data Transfer Object - DTO)**: Đóng gói dữ liệu giữa các lớp

## Kết quả đạt được

### Chức năng xác thực người dùng
- Đăng nhập an toàn với phân quyền Admin/Staff
- Xử lý thông báo lỗi khi nhập sai tên tài khoản/mật khẩu
- Bảo mật thông tin tài khoản

![image](https://github.com/user-attachments/assets/486b4173-b0d2-465e-aac1-b2f1e53761aa)

### Chức năng khôi phục tài khoản
- Tài khoản không bị xóa hoàn toàn, có thể khôi phục lại trong trường hợp cần thiết
- Hỗ trợ quản lý tài khoản linh hoạt

![image](https://github.com/user-attachments/assets/8c5f96ed-3328-4c51-8169-f670ee878088)


### Chức năng tạo hóa đơn và thanh toán
- Hiển thị trạng thái bàn bằng màu sắc trực quan (trống/có người)
- Hỗ trợ tính năng giảm giá khi thanh toán
- Tự động cập nhật trạng thái bàn sau khi thanh toán

![image](https://github.com/user-attachments/assets/612814f2-b2e9-488c-9f2e-8c45761334e8)

![image](https://github.com/user-attachments/assets/393fe044-13ca-462b-a3c7-2436ec22ee70)

### Chức năng quản lý thực đơn
- Tìm kiếm món ăn theo từ khóa
- Thêm/sửa/xóa món ăn và danh mục dễ dàng
- Hiển thị thông tin món ăn trực quan

![image](https://github.com/user-attachments/assets/5ca9cd38-434d-4f1b-887c-b1882015fe3e)

### Chức năng ghi log hoạt động
- Ghi lại các hoạt động đăng nhập, thanh toán, tạo hóa đơn
- Hỗ trợ kiểm soát và theo dõi hoạt động hệ thống

![image](https://github.com/user-attachments/assets/fdf40f1c-f374-42f4-965f-cd3e373539a3)

### Báo cáo thống kê
- Báo cáo doanh thu theo mốc thời gian tùy chọn (Ngày/Tháng/Năm)
- Báo cáo món ăn bán chạy
- Báo cáo những món ăn thường được mua cùng nhau

![image](https://github.com/user-attachments/assets/48d9bf71-3633-41af-9a54-319b6f3ca988)

![image](https://github.com/user-attachments/assets/99d85a54-8834-4107-85f7-136b098040df)

![image](https://github.com/user-attachments/assets/10005ceb-0935-45f2-b9f2-516a66108a2d)

## Cài đặt

### Yêu cầu hệ thống

- Windows 7 trở lên
- .NET Framework 4.5 trở lên
- SQL Server 2014 trở lên

### Các bước cài đặt

1. Clone repository từ GitHub:
```
[git clone https://github.com/Trinhnnt/QuanLyQuanCafe.git](https://github.com/Trinhnnt/QuanLyQuanCafe.git)
```
2. Mở SQL Server Management Studio và chạy script cơ sở dữ liệu `DataSQL`

3. Mở project trong Visual Studio và cấu hình chuỗi kết nối trong file `DataProvider.cs`

4. Build và chạy ứng dụng

## Hướng dẫn sử dụng

### Đăng nhập
- Sử dụng tài khoản mặc định:
  - Admin: Username: `admin`, Password: `1`
  - Staff: Username: `staff`, Password: `1`

### Quản lý bàn và gọi món
1. Chọn bàn từ danh sách bàn
2. Chọn danh mục và món ăn từ menu
3. Nhập số lượng và nhấn "Thêm món"
4. Để thanh toán, nhập % giảm giá (nếu có) và nhấn "Thanh toán"

### Quản lý thực đơn (Admin)
1. Chuyển đến tab "Thực đơn" trong giao diện Admin
2. Sử dụng các nút "Thêm", "Xóa", "Sửa", "Tìm Kiếm" để quản lý món ăn

### Xem báo cáo doanh thu (Admin)
1. Chuyển đến tab "Doanh thu" trong giao diện Admin
2. Chọn khoảng thời gian và nhấn "Tạo báo cáo"

## Ưu điểm của hệ thống

1. **Tổ chức theo mô hình ba lớp rõ ràng**
   - Source code được chia thành các lớp: DAO, DTO và Form giao diện
   - Việc tách lớp giúp dễ bảo trì, tái sử dụng và mở rộng chức năng

2. **Giao diện trực quan, dễ sử dụng**
   - Sử dụng WinForms, phân chia tab, nhóm chức năng rõ ràng
   - Các form được thiết kế gọn gàng, dễ thao tác

3. **Tích hợp chức năng báo cáo**
   - Hệ thống có sử dụng các DataSet cho phép xuất thống kê
   - Hỗ trợ ra quyết định kinh doanh nhanh hơn

4. **Có lớp truy cập cơ sở dữ liệu riêng biệt**
   - Lớp DataProvider đảm bảo an toàn và tránh SQL Injection

5. **Tích hợp quản lý tài khoản và phân quyền**
   - Phân biệt rõ quyền Admin và nhân viên

## Hạn chế và hướng phát triển

### Hạn chế hiện tại
- Giao diện chưa thực sự hiện đại, chưa hỗ trợ giao diện thích ứng
- Chưa có chức năng quản lý tồn kho và nguyên liệu

### Hướng phát triển
- **Mở rộng chức năng**: Tích hợp đặt bàn trước, giảm giá theo khung giờ, gộp/chia hóa đơn
- **Cải tiến bảo mật**: Mã hóa mật khẩu an toàn hơn, ghi log đầy đủ
- **Tích hợp hệ thống khác**: Kết nối máy in hóa đơn, thanh toán điện tử, đồng bộ dữ liệu với cloud

## Cấu trúc cơ sở dữ liệu

Hệ thống sử dụng các bảng chính:
- **Account**: Quản lý tài khoản người dùng
- **AccountType**: Phân loại tài khoản
- **Food**: Thông tin món ăn
- **FoodCategory**: Danh mục món ăn
- **TableFood**: Thông tin bàn
- **Bill**: Hóa đơn
- **BillInfo**: Chi tiết hóa đơn
- **ActivityLog**: Ghi log hoạt động

## Tác giả

- Nguyễn Ngọc Tú Trinh
- Đặng Vũ Sơn
- Nguyễn Thành Vững

## Liên hệ

Nếu có bất kỳ câu hỏi hoặc góp ý nào, vui lòng liên hệ qua email: [nguyenngoctutrinh92@gmail.com]

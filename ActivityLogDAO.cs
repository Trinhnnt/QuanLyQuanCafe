using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class ActivityLogDAO
    {
        private static ActivityLogDAO instance;

        public static ActivityLogDAO Instance
        {
            get { if (instance == null) instance = new ActivityLogDAO(); return ActivityLogDAO.instance; }
            private set { ActivityLogDAO.instance = value; }
        }

        private ActivityLogDAO() { }

        /// <summary>
        /// Ghi log hoạt động vào cơ sở dữ liệu
        /// </summary>
        /// <param name="userId">Tên đăng nhập của người dùng</param>
        /// <param name="action">Hành động thực hiện (Login, Logout, Insert, Update, Delete...)</param>
        /// <param name="description">Mô tả chi tiết về hành động</param>
        /// <param name="entityName">Tên đối tượng tác động (Table, Food, Bill...)</param>
        /// <param name="entityId">ID của đối tượng (nếu có)</param>
        /// <returns>True nếu ghi log thành công</returns>
        public bool LogActivity(string userId, string action, string description, string entityName = null, string entityId = null)
        {
            try
            {
                string ipAddress = GetLocalIPAddress();
                string userAgent = Environment.OSVersion.ToString();

                int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertActivityLog @userId , @action , @description , @entityName , @entityId , @ipAddress , @userAgent",
                    new object[] { userId, action, description, entityName, entityId, ipAddress, userAgent });

                return result > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi vào file nếu không thể ghi vào database
                LogToFile("Error logging activity: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách log hoạt động theo khoảng thời gian
        /// </summary>
        public List<ActivityLogDTO> GetActivityLogs(DateTime fromDate, DateTime toDate, string userId = null)
        {
            List<ActivityLogDTO> logs = new List<ActivityLogDTO>();

            string query = "SELECT * FROM ActivityLog WHERE LogTime BETWEEN @fromDate AND @toDate";
            if (!string.IsNullOrEmpty(userId))
                query += " AND UserId = @userId";

            query += " ORDER BY LogTime DESC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new object[] { fromDate, toDate.AddDays(1), userId });

            foreach (DataRow row in data.Rows)
            {
                ActivityLogDTO log = new ActivityLogDTO(row);
                logs.Add(log);
            }

            return logs;
        }

        /// <summary>
        /// Lấy địa chỉ IP của máy tính hiện tại
        /// </summary>
        private string GetLocalIPAddress()
        {
            try
            {
                string hostName = Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                foreach (IPAddress ip in hostEntry.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }

                return "127.0.0.1";
            }
            catch
            {
                return "Unknown";
            }
        }

        /// <summary>
        /// Ghi log vào file khi không thể ghi vào database
        /// </summary>
        private void LogToFile(string message)
        {
            try
            {
                string logFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

                if (!System.IO.Directory.Exists(logFolder))
                    System.IO.Directory.CreateDirectory(logFolder);

                string logFile = System.IO.Path.Combine(logFolder, $"ErrorLog_{DateTime.Now:yyyyMMdd}.txt");

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFile, true))
                {
                    writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
                }
            }
            catch
            {
                // Không làm gì nếu không thể ghi file
            }
        }
    }
}

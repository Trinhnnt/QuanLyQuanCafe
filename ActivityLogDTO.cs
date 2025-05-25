using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class ActivityLogDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public DateTime LogTime { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }

        public ActivityLogDTO(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.UserId = row["UserId"].ToString();
            this.Action = row["Action"].ToString();
            this.Description = row["Description"].ToString();
            this.EntityName = row["EntityName"] != DBNull.Value ? row["EntityName"].ToString() : null;
            this.EntityId = row["EntityId"] != DBNull.Value ? row["EntityId"].ToString() : null;
            this.LogTime = (DateTime)row["LogTime"];
            this.IPAddress = row["IPAddress"] != DBNull.Value ? row["IPAddress"].ToString() : null;
            this.UserAgent = row["UserAgent"] != DBNull.Value ? row["UserAgent"].ToString() : null;
        }
    }
}

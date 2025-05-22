using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        private string status;
        private string name;        
        private int iD;
        private int isActive;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int IsActive { get => isActive; set => isActive = value; }

        public Table(int id, string name, string status, int isActive)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.IsActive = isActive;
        }
        public Table(DataRow row) 
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
            if (row.Table.Columns.Contains("isActive") && row["isActive"] != DBNull.Value)
            {
                this.IsActive = Convert.ToInt32(row["isActive"]);
            }
            else
            {
                this.IsActive = 1;
            }
        }

    }
}

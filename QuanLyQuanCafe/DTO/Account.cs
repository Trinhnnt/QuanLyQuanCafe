using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        private string userName;
        private string displayName;
        private int type;
        private string password;
        private int status;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public int Status { get => status; set => status = value; }

        public Account(string userName, string displayName, int type, string password = null) 
        { 
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.Password = password;
            this.Status = status;
        }

        public Account(DataRow row)
        {
            foreach (DataColumn col in row.Table.Columns)
            {
                if (string.Equals(col.ColumnName, "username", StringComparison.OrdinalIgnoreCase))
                    this.UserName = row[col.ColumnName].ToString();
                else if (string.Equals(col.ColumnName, "displayname", StringComparison.OrdinalIgnoreCase))
                    this.DisplayName = row[col.ColumnName].ToString();
                else if (string.Equals(col.ColumnName, "type", StringComparison.OrdinalIgnoreCase))
                    this.Type = Convert.ToInt32(row[col.ColumnName]);
                else if (string.Equals(col.ColumnName, "password", StringComparison.OrdinalIgnoreCase))
                    this.Password = row[col.ColumnName].ToString();
                this.Status = row["Status"] != DBNull.Value ? (int)row["Status"] : 1;
            }
        }
        
    }
}

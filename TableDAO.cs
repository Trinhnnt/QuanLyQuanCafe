using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static int TableWidth = 100;
        public static int TableHeight = 100;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { instance = value; }
        }

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows) 
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public List<Table> LoadListAllTable()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TableFood");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }
        public void SwitchTable (int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2", new object[]{id1,id2});
        }
        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT dbo.TableFood(name, status) VALUES (N'{0}',N'{1}')", name,status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateTable(int idTable, string name, string status)
        {
            string query = string.Format("UPDATE dbo.TableFood SET name =N'{0}' , status = N'{1}' WHERE id = {2}", name,status,idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int idTable, string status)
        {
            if(status != "Trống")
            {
                return false;
            }
            string query = string.Format("UPDATE TableFood SET isActive = 0 WHERE id = {0} AND status=N'{1}'", idTable, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class AccountTypeDAO
    {
        private static AccountTypeDAO instance;

        public static AccountTypeDAO Instance
        {
            get { if (instance == null) instance = new AccountTypeDAO(); return AccountTypeDAO.instance; }
            private set { instance = value; }
        }

        private AccountTypeDAO() { }

        public List<AccountType> GetAccountTypes()
        {
            List<AccountType> typeList = new List<AccountType>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetAccountTypes");

            foreach (DataRow item in data.Rows)
            {
                AccountType type = new AccountType(item);
                typeList.Add(type);
            }

            return typeList;
        }

        public string GetAccountTypeName(int typeId)
        {
            string query = "SELECT name FROM AccountType WHERE id = @typeId";
            object[] parameters = new object[] { typeId };
            DataTable result = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (result.Rows.Count > 0)
                return result.Rows[0]["name"].ToString();

            return "Unknown";
        }
    }
}

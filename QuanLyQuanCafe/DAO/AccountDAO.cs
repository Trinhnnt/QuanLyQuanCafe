using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password) 
        {

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, hasPass });

            bool loginSuccess = result.Rows.Count > 0;

            // Ghi log kết quả đăng nhập
            string action = "Login";
            string description = loginSuccess ?
                "Đăng nhập thành công" :
                "Đăng nhập thất bại";

            ActivityLogDAO.Instance.LogActivity(
                username,
                action,
                description,
                "Account",
                username);

            return loginSuccess;
        }
        public Account GetAccountByUserName(string userName) 
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM account WHERE userName = '" + userName +"'");
            foreach (DataRow item in data.Rows) 
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            byte[] tempCurrent = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasDataCurrent = new MD5CryptoServiceProvider().ComputeHash(tempCurrent);

            string hashedPass = "";
            foreach (byte item in hasDataCurrent)
            {
                hashedPass += item;
            }
            string hashedNewPass = "";
            if (!string.IsNullOrEmpty(newPass))
            {
                byte[] tempNew = ASCIIEncoding.ASCII.GetBytes(newPass);
                byte[] hasDataNew = new MD5CryptoServiceProvider().ComputeHash(tempNew);

                foreach (byte item in hasDataNew)
                {
                    hashedNewPass += item;
                }
            }

            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword",
        new object[] { userName, displayName, hashedPass, hashedNewPass });
            string action = "UpdateAccount";
            string description = result > 0 ?
                "Cập nhật thông tin tài khoản thành công" :
                "Cập nhật thông tin tài khoản thất bại";

            ActivityLogDAO.Instance.LogActivity(
                userName,
                action,
                description,
                "Account",
                userName);

            return result > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type , Status FROM dbo.Account");
        }
        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type, password )VALUES  ( N'{0}', N'{1}', {2}, N'{3}')", name, displayName, type, "1962026656160185351301320480154111117132155");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}', Type = {2} WHERE UserName = N'{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("UPDATE dbo.Account SET Status = 0 WHERE UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = N'1962026656160185351301320480154111117132155' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool RestoreAccount(string name)
        {
            string query = string.Format("UPDATE dbo.Account SET Status = 1 WHERE UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}

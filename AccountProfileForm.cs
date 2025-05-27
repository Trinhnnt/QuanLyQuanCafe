using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class AccountProfileForm : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public AccountProfileForm(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            UserNameTextBox.Text = LoginAccount.UserName;
            DisplayNameTextBox.Text = LoginAccount.DisplayName;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(DisplayNameTextBox.Text))
            {
                MessageBox.Show("Tên hiển thị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DisplayNameTextBox.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PassWordTextBox.Text))
            {
                MessageBox.Show("Mật khẩu hiện tại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PassWordTextBox.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(NewPassWordTextBox.Text) || !string.IsNullOrEmpty(ReEnterPassWordTextBox.Text))
            {
                if (NewPassWordTextBox.Text != ReEnterPassWordTextBox.Text)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu phải giống nhau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NewPassWordTextBox.Focus();
                    return false;
                }
                if (NewPassWordTextBox.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NewPassWordTextBox.Focus();
                    return false;
                }
            }
            return true;
        }
        void UpdateAccountInfo()
        {
            if (!ValidateInputs())
                return;

            string displayName = DisplayNameTextBox.Text.Trim();
            string password = PassWordTextBox.Text;
            string newpass = NewPassWordTextBox.Text;
            string userName = UserNameTextBox.Text;

            try
            {
                bool result = AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass);
                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Nếu cập nhật thành công, có thể update lại loginAccount
                    loginAccount.DisplayName = displayName;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra lại mật khẩu hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật thông tin:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}

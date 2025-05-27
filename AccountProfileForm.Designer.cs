namespace QuanLyQuanCafe
{
    partial class AccountProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox DisplayNameTextBox;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.TextBox PassWordTextBox;
        private System.Windows.Forms.Label lblNewPassWord;
        private System.Windows.Forms.TextBox NewPassWordTextBox;
        private System.Windows.Forms.Label lblReEnterPassWord;
        private System.Windows.Forms.TextBox ReEnterPassWordTextBox;
        private System.Windows.Forms.Button UpdateButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUserName = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.DisplayNameTextBox = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.PassWordTextBox = new System.Windows.Forms.TextBox();
            this.lblNewPassWord = new System.Windows.Forms.Label();
            this.NewPassWordTextBox = new System.Windows.Forms.TextBox();
            this.lblReEnterPassWord = new System.Windows.Forms.Label();
            this.ReEnterPassWordTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(30, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(95, 19);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Tên tài khoản";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserNameTextBox.Location = new System.Drawing.Point(160, 22);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ReadOnly = true;
            this.UserNameTextBox.Size = new System.Drawing.Size(230, 25);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.Location = new System.Drawing.Point(30, 65);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(97, 19);
            this.lblDisplayName.TabIndex = 2;
            this.lblDisplayName.Text = "Tên hiển thị *";
            // 
            // DisplayNameTextBox
            // 
            this.DisplayNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DisplayNameTextBox.Location = new System.Drawing.Point(160, 62);
            this.DisplayNameTextBox.Name = "DisplayNameTextBox";
            this.DisplayNameTextBox.Size = new System.Drawing.Size(230, 25);
            this.DisplayNameTextBox.TabIndex = 3;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassWord.Location = new System.Drawing.Point(30, 105);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(91, 19);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "Mật khẩu cũ *";
            // 
            // PassWordTextBox
            // 
            this.PassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PassWordTextBox.Location = new System.Drawing.Point(160, 102);
            this.PassWordTextBox.Name = "PassWordTextBox";
            this.PassWordTextBox.PasswordChar = '*';
            this.PassWordTextBox.Size = new System.Drawing.Size(230, 25);
            this.PassWordTextBox.TabIndex = 5;
            // 
            // lblNewPassWord
            // 
            this.lblNewPassWord.AutoSize = true;
            this.lblNewPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewPassWord.Location = new System.Drawing.Point(30, 145);
            this.lblNewPassWord.Name = "lblNewPassWord";
            this.lblNewPassWord.Size = new System.Drawing.Size(108, 19);
            this.lblNewPassWord.TabIndex = 6;
            this.lblNewPassWord.Text = "Mật khẩu mới";
            // 
            // NewPassWordTextBox
            // 
            this.NewPassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.NewPassWordTextBox.Location = new System.Drawing.Point(160, 142);
            this.NewPassWordTextBox.Name = "NewPassWordTextBox";
            this.NewPassWordTextBox.PasswordChar = '*';
            this.NewPassWordTextBox.Size = new System.Drawing.Size(230, 25);
            this.NewPassWordTextBox.TabIndex = 7;
            // 
            // lblReEnterPassWord
            // 
            this.lblReEnterPassWord.AutoSize = true;
            this.lblReEnterPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReEnterPassWord.Location = new System.Drawing.Point(30, 185);
            this.lblReEnterPassWord.Name = "lblReEnterPassWord";
            this.lblReEnterPassWord.Size = new System.Drawing.Size(123, 19);
            this.lblReEnterPassWord.TabIndex = 8;
            this.lblReEnterPassWord.Text = "Nhập lại mật khẩu";
            // 
            // ReEnterPassWordTextBox
            // 
            this.ReEnterPassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ReEnterPassWordTextBox.Location = new System.Drawing.Point(160, 182);
            this.ReEnterPassWordTextBox.Name = "ReEnterPassWordTextBox";
            this.ReEnterPassWordTextBox.PasswordChar = '*';
            this.ReEnterPassWordTextBox.Size = new System.Drawing.Size(230, 25);
            this.ReEnterPassWordTextBox.TabIndex = 9;
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackColor = System.Drawing.Color.SteelBlue;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(160, 230);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(230, 35);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Cập nhật thông tin";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // AccountProfileForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(430, 290);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ReEnterPassWordTextBox);
            this.Controls.Add(this.lblReEnterPassWord);
            this.Controls.Add(this.NewPassWordTextBox);
            this.Controls.Add(this.lblNewPassWord);
            this.Controls.Add(this.PassWordTextBox);
            this.Controls.Add(this.lblPassWord);
            this.Controls.Add(this.DisplayNameTextBox);
            this.Controls.Add(this.lblDisplayName);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.lblUserName);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccountProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

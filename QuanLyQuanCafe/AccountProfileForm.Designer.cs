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
        private System.Windows.Forms.TableLayoutPanel ProfileTableLayoutPanel;
        private System.Windows.Forms.Panel panel1;

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
            this.ProfileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ReEnterPassWordTextBox = new System.Windows.Forms.TextBox();
            this.lblReEnterPassWord = new System.Windows.Forms.Label();
            this.NewPassWordTextBox = new System.Windows.Forms.TextBox();
            this.lblNewPassWord = new System.Windows.Forms.Label();
            this.PassWordTextBox = new System.Windows.Forms.TextBox();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.DisplayNameTextBox = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.ProfileTableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfileTableLayoutPanel
            // 
            this.ProfileTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.ProfileTableLayoutPanel.ColumnCount = 3;
            this.ProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.ProfileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ProfileTableLayoutPanel.Controls.Add(this.panel1, 1, 1);
            this.ProfileTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfileTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ProfileTableLayoutPanel.Name = "ProfileTableLayoutPanel";
            this.ProfileTableLayoutPanel.RowCount = 3;
            this.ProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.ProfileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ProfileTableLayoutPanel.Size = new System.Drawing.Size(480, 350);
            this.ProfileTableLayoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.UpdateButton);
            this.panel1.Controls.Add(this.ReEnterPassWordTextBox);
            this.panel1.Controls.Add(this.lblReEnterPassWord);
            this.panel1.Controls.Add(this.NewPassWordTextBox);
            this.panel1.Controls.Add(this.lblNewPassWord);
            this.panel1.Controls.Add(this.PassWordTextBox);
            this.panel1.Controls.Add(this.lblPassWord);
            this.panel1.Controls.Add(this.DisplayNameTextBox);
            this.panel1.Controls.Add(this.lblDisplayName);
            this.panel1.Controls.Add(this.UserNameTextBox);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(27, 20);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(426, 309);
            this.panel1.TabIndex = 0;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Location = new System.Drawing.Point(150, 230);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(250, 40);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Cập nhật thông tin";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ReEnterPassWordTextBox
            // 
            this.ReEnterPassWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReEnterPassWordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReEnterPassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ReEnterPassWordTextBox.Location = new System.Drawing.Point(150, 182);
            this.ReEnterPassWordTextBox.Name = "ReEnterPassWordTextBox";
            this.ReEnterPassWordTextBox.PasswordChar = '•';
            this.ReEnterPassWordTextBox.Size = new System.Drawing.Size(250, 30);
            this.ReEnterPassWordTextBox.TabIndex = 9;
            // 
            // lblReEnterPassWord
            // 
            this.lblReEnterPassWord.AutoSize = true;
            this.lblReEnterPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReEnterPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblReEnterPassWord.Location = new System.Drawing.Point(20, 185);
            this.lblReEnterPassWord.Name = "lblReEnterPassWord";
            this.lblReEnterPassWord.Size = new System.Drawing.Size(158, 23);
            this.lblReEnterPassWord.TabIndex = 8;
            this.lblReEnterPassWord.Text = "Nhập lại mật khẩu";
            // 
            // NewPassWordTextBox
            // 
            this.NewPassWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewPassWordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewPassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.NewPassWordTextBox.Location = new System.Drawing.Point(150, 142);
            this.NewPassWordTextBox.Name = "NewPassWordTextBox";
            this.NewPassWordTextBox.PasswordChar = '•';
            this.NewPassWordTextBox.Size = new System.Drawing.Size(250, 30);
            this.NewPassWordTextBox.TabIndex = 7;
            // 
            // lblNewPassWord
            // 
            this.lblNewPassWord.AutoSize = true;
            this.lblNewPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblNewPassWord.Location = new System.Drawing.Point(20, 145);
            this.lblNewPassWord.Name = "lblNewPassWord";
            this.lblNewPassWord.Size = new System.Drawing.Size(123, 23);
            this.lblNewPassWord.TabIndex = 6;
            this.lblNewPassWord.Text = "Mật khẩu mới";
            // 
            // PassWordTextBox
            // 
            this.PassWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassWordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PassWordTextBox.Location = new System.Drawing.Point(150, 102);
            this.PassWordTextBox.Name = "PassWordTextBox";
            this.PassWordTextBox.PasswordChar = '•';
            this.PassWordTextBox.Size = new System.Drawing.Size(250, 30);
            this.PassWordTextBox.TabIndex = 5;
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblPassWord.Location = new System.Drawing.Point(20, 105);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(122, 23);
            this.lblPassWord.TabIndex = 4;
            this.lblPassWord.Text = "Mật khẩu cũ *";
            // 
            // DisplayNameTextBox
            // 
            this.DisplayNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DisplayNameTextBox.Location = new System.Drawing.Point(150, 62);
            this.DisplayNameTextBox.Name = "DisplayNameTextBox";
            this.DisplayNameTextBox.Size = new System.Drawing.Size(250, 30);
            this.DisplayNameTextBox.TabIndex = 3;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDisplayName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDisplayName.Location = new System.Drawing.Point(20, 65);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(116, 23);
            this.lblDisplayName.TabIndex = 2;
            this.lblDisplayName.Text = "Tên hiển thị *";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.UserNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserNameTextBox.Location = new System.Drawing.Point(150, 22);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ReadOnly = true;
            this.UserNameTextBox.Size = new System.Drawing.Size(250, 30);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblUserName.Location = new System.Drawing.Point(20, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(117, 23);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Tên tài khoản";
            // 
            // AccountProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(480, 350);
            this.Controls.Add(this.ProfileTableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "AccountProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.ProfileTableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}

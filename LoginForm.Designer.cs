namespace QuanLyQuanCafe
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PassWordTextBox = new System.Windows.Forms.TextBox();
            this.PassWordLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.LoginButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 202);
            this.panel1.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Font = new System.Drawing.Font("Helvetica World", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(345, 167);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 30);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Thoát";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.DarkCyan;
            this.LoginButton.Font = new System.Drawing.Font("Helvetica World", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LoginButton.Location = new System.Drawing.Point(234, 167);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(105, 30);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Đăng nhập";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.PassWordTextBox);
            this.panel3.Controls.Add(this.PassWordLabel);
            this.panel3.Location = new System.Drawing.Point(3, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(462, 76);
            this.panel3.TabIndex = 2;
            // 
            // PassWordTextBox
            // 
            this.PassWordTextBox.BackColor = System.Drawing.Color.Beige;
            this.PassWordTextBox.Location = new System.Drawing.Point(173, 24);
            this.PassWordTextBox.Name = "PassWordTextBox";
            this.PassWordTextBox.Size = new System.Drawing.Size(280, 22);
            this.PassWordTextBox.TabIndex = 2;
            this.PassWordTextBox.Text = "1";
            this.PassWordTextBox.UseSystemPasswordChar = true;
            // 
            // PassWordLabel
            // 
            this.PassWordLabel.AutoSize = true;
            this.PassWordLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassWordLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.PassWordLabel.Location = new System.Drawing.Point(17, 25);
            this.PassWordLabel.Name = "PassWordLabel";
            this.PassWordLabel.Size = new System.Drawing.Size(91, 19);
            this.PassWordLabel.TabIndex = 0;
            this.PassWordLabel.Text = "Mật khẩu: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UserNameTextBox);
            this.panel2.Controls.Add(this.UserNameLabel);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 76);
            this.panel2.TabIndex = 0;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.BackColor = System.Drawing.Color.Beige;
            this.UserNameTextBox.Location = new System.Drawing.Point(173, 23);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(280, 22);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.Text = "admin";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.UserNameLabel.Location = new System.Drawing.Point(17, 26);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(132, 19);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "Tên đăng nhập:";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(492, 221);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox PassWordTextBox;
        private System.Windows.Forms.Label PassWordLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LoginButton;
    }
}


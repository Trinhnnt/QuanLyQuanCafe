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
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.buttonFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.credentialsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PassWordLabel = new System.Windows.Forms.Label();
            this.PassWordTextBox = new System.Windows.Forms.TextBox();
            this.formDragPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.buttonFlowLayoutPanel.SuspendLayout();
            this.credentialsTableLayoutPanel.SuspendLayout();
            this.formDragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.headerLabel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.contentPanel, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 30);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(500, 270);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.headerLabel.Location = new System.Drawing.Point(23, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(454, 50);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.Controls.Add(this.buttonFlowLayoutPanel);
            this.contentPanel.Controls.Add(this.credentialsTableLayoutPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(23, 73);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15);
            this.contentPanel.Size = new System.Drawing.Size(454, 174);
            this.contentPanel.TabIndex = 1;
            // 
            // buttonFlowLayoutPanel
            // 
            this.buttonFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFlowLayoutPanel.AutoSize = true;
            this.buttonFlowLayoutPanel.Controls.Add(this.ExitButton);
            this.buttonFlowLayoutPanel.Controls.Add(this.LoginButton);
            this.buttonFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowLayoutPanel.Location = new System.Drawing.Point(214, 124);
            this.buttonFlowLayoutPanel.Name = "buttonFlowLayoutPanel";
            this.buttonFlowLayoutPanel.Size = new System.Drawing.Size(223, 41);
            this.buttonFlowLayoutPanel.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(120, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 35);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Thoát";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(3, 3);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(111, 35);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "Đăng nhập";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // credentialsTableLayoutPanel
            // 
            this.credentialsTableLayoutPanel.ColumnCount = 2;
            this.credentialsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.credentialsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.credentialsTableLayoutPanel.Controls.Add(this.UserNameLabel, 0, 0);
            this.credentialsTableLayoutPanel.Controls.Add(this.UserNameTextBox, 1, 0);
            this.credentialsTableLayoutPanel.Controls.Add(this.PassWordLabel, 0, 1);
            this.credentialsTableLayoutPanel.Controls.Add(this.PassWordTextBox, 1, 1);
            this.credentialsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.credentialsTableLayoutPanel.Location = new System.Drawing.Point(15, 15);
            this.credentialsTableLayoutPanel.Name = "credentialsTableLayoutPanel";
            this.credentialsTableLayoutPanel.RowCount = 2;
            this.credentialsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.credentialsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.credentialsTableLayoutPanel.Size = new System.Drawing.Size(424, 100);
            this.credentialsTableLayoutPanel.TabIndex = 0;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.UserNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.UserNameLabel.Location = new System.Drawing.Point(3, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(142, 50);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "Tên đăng nhập:";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.UserNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.UserNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.UserNameTextBox.Location = new System.Drawing.Point(151, 10);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(270, 30);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // PassWordLabel
            // 
            this.PassWordLabel.AutoSize = true;
            this.PassWordLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PassWordLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.PassWordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.PassWordLabel.Location = new System.Drawing.Point(3, 50);
            this.PassWordLabel.Name = "PassWordLabel";
            this.PassWordLabel.Size = new System.Drawing.Size(142, 50);
            this.PassWordLabel.TabIndex = 2;
            this.PassWordLabel.Text = "Mật khẩu:";
            this.PassWordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PassWordTextBox
            // 
            this.PassWordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PassWordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.PassWordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassWordTextBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PassWordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.PassWordTextBox.Location = new System.Drawing.Point(151, 60);
            this.PassWordTextBox.Name = "PassWordTextBox";
            this.PassWordTextBox.Size = new System.Drawing.Size(270, 30);
            this.PassWordTextBox.TabIndex = 2;
            this.PassWordTextBox.UseSystemPasswordChar = true;
            // 
            // formDragPanel
            // 
            this.formDragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.formDragPanel.Controls.Add(this.closeButton);
            this.formDragPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.formDragPanel.Location = new System.Drawing.Point(0, 0);
            this.formDragPanel.Name = "formDragPanel";
            this.formDragPanel.Size = new System.Drawing.Size(500, 30);
            this.formDragPanel.TabIndex = 0;
            this.formDragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDragPanel_MouseDown);
            this.formDragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormDragPanel_MouseMove);
            this.formDragPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormDragPanel_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(470, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(30, 30);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.ExitButton;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.formDragPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(450, 300);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.buttonFlowLayoutPanel.ResumeLayout(false);
            this.credentialsTableLayoutPanel.ResumeLayout(false);
            this.credentialsTableLayoutPanel.PerformLayout();
            this.formDragPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel credentialsTableLayoutPanel;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label PassWordLabel;
        private System.Windows.Forms.TextBox PassWordTextBox;
        private System.Windows.Forms.FlowLayoutPanel buttonFlowLayoutPanel;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel formDragPanel;
        private System.Windows.Forms.Button closeButton;

        // Thêm các biến và phương thức để hỗ trợ kéo form
        private bool isDragging = false;
        private System.Drawing.Point lastLocation;

        private void FormDragPanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;
        }

        private void FormDragPanel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Location = new System.Drawing.Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void FormDragPanel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}

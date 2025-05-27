namespace QuanLyQuanCafe
{
    partial class TableManagerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BillListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalPriceTextBox = new System.Windows.Forms.TextBox();
            this.SwitchTableComboBox = new System.Windows.Forms.ComboBox();
            this.SwitchTableButton = new System.Windows.Forms.Button();
            this.DiscountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.CheckOutButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.FoodCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddFoodButton = new System.Windows.Forms.Button();
            this.FoodComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TableFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountNumericUpDown)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoodCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.adminToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.thôngTinTàiKhoảnToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.thôngTinCáNhânToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.đăngXuấtToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.BillListView);
            this.panel2.Location = new System.Drawing.Point(368, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 408);
            this.panel2.TabIndex = 2;
            // 
            // BillListView
            // 
            this.BillListView.BackColor = System.Drawing.Color.White;
            this.BillListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BillListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.BillListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BillListView.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BillListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BillListView.FullRowSelect = true;
            this.BillListView.GridLines = true;
            this.BillListView.HideSelection = false;
            this.BillListView.Location = new System.Drawing.Point(0, 0);
            this.BillListView.Name = "BillListView";
            this.BillListView.Size = new System.Drawing.Size(554, 408);
            this.BillListView.TabIndex = 0;
            this.BillListView.UseCompatibleStateImageBehavior = false;
            this.BillListView.View = System.Windows.Forms.View.Details;
            this.BillListView.SelectedIndexChanged += new System.EventHandler(this.BillListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 140;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.TotalPriceTextBox);
            this.panel3.Controls.Add(this.SwitchTableComboBox);
            this.panel3.Controls.Add(this.SwitchTableButton);
            this.panel3.Controls.Add(this.DiscountNumericUpDown);
            this.panel3.Controls.Add(this.CheckOutButton);
            this.panel3.Location = new System.Drawing.Point(368, 515);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 66);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(112, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Giảm giá:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(112, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tổng tiền:";
            // 
            // TotalPriceTextBox
            // 
            this.TotalPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalPriceTextBox.BackColor = System.Drawing.Color.White;
            this.TotalPriceTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TotalPriceTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.TotalPriceTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.TotalPriceTextBox.Location = new System.Drawing.Point(202, 31);
            this.TotalPriceTextBox.Name = "TotalPriceTextBox";
            this.TotalPriceTextBox.ReadOnly = true;
            this.TotalPriceTextBox.Size = new System.Drawing.Size(234, 30);
            this.TotalPriceTextBox.TabIndex = 7;
            this.TotalPriceTextBox.Text = "0";
            this.TotalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalPriceTextBox.TextChanged += new System.EventHandler(this.TotalPriceTextBox_TextChanged);
            // 
            // SwitchTableComboBox
            // 
            this.SwitchTableComboBox.BackColor = System.Drawing.Color.White;
            this.SwitchTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SwitchTableComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SwitchTableComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SwitchTableComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SwitchTableComboBox.FormattingEnabled = true;
            this.SwitchTableComboBox.Location = new System.Drawing.Point(3, 35);
            this.SwitchTableComboBox.Name = "SwitchTableComboBox";
            this.SwitchTableComboBox.Size = new System.Drawing.Size(102, 28);
            this.SwitchTableComboBox.TabIndex = 4;
            // 
            // SwitchTableButton
            // 
            this.SwitchTableButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.SwitchTableButton.FlatAppearance.BorderSize = 0;
            this.SwitchTableButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchTableButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.SwitchTableButton.ForeColor = System.Drawing.Color.White;
            this.SwitchTableButton.Location = new System.Drawing.Point(3, 3);
            this.SwitchTableButton.Name = "SwitchTableButton";
            this.SwitchTableButton.Size = new System.Drawing.Size(102, 29);
            this.SwitchTableButton.TabIndex = 6;
            this.SwitchTableButton.Text = "Chuyển bàn";
            this.SwitchTableButton.UseVisualStyleBackColor = false;
            this.SwitchTableButton.Click += new System.EventHandler(this.SwitchTableButton_Click);
            // 
            // DiscountNumericUpDown
            // 
            this.DiscountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountNumericUpDown.BackColor = System.Drawing.Color.White;
            this.DiscountNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscountNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DiscountNumericUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.DiscountNumericUpDown.Location = new System.Drawing.Point(202, 3);
            this.DiscountNumericUpDown.Name = "DiscountNumericUpDown";
            this.DiscountNumericUpDown.Size = new System.Drawing.Size(234, 27);
            this.DiscountNumericUpDown.TabIndex = 4;
            this.DiscountNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CheckOutButton
            // 
            this.CheckOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.CheckOutButton.FlatAppearance.BorderSize = 0;
            this.CheckOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckOutButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.CheckOutButton.ForeColor = System.Drawing.Color.White;
            this.CheckOutButton.Location = new System.Drawing.Point(442, 3);
            this.CheckOutButton.Name = "CheckOutButton";
            this.CheckOutButton.Size = new System.Drawing.Size(112, 56);
            this.CheckOutButton.TabIndex = 4;
            this.CheckOutButton.Text = "Thanh toán";
            this.CheckOutButton.UseVisualStyleBackColor = false;
            this.CheckOutButton.Click += new System.EventHandler(this.CheckOutButton_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.FoodCountNumericUpDown);
            this.panel4.Controls.Add(this.AddFoodButton);
            this.panel4.Controls.Add(this.FoodComboBox);
            this.panel4.Controls.Add(this.CategoryComboBox);
            this.panel4.Location = new System.Drawing.Point(368, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(554, 64);
            this.panel4.TabIndex = 4;
            // 
            // FoodCountNumericUpDown
            // 
            this.FoodCountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FoodCountNumericUpDown.BackColor = System.Drawing.Color.White;
            this.FoodCountNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FoodCountNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FoodCountNumericUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FoodCountNumericUpDown.Location = new System.Drawing.Point(500, 20);
            this.FoodCountNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.FoodCountNumericUpDown.Name = "FoodCountNumericUpDown";
            this.FoodCountNumericUpDown.Size = new System.Drawing.Size(51, 27);
            this.FoodCountNumericUpDown.TabIndex = 3;
            this.FoodCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddFoodButton
            // 
            this.AddFoodButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFoodButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.AddFoodButton.FlatAppearance.BorderSize = 0;
            this.AddFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFoodButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.AddFoodButton.ForeColor = System.Drawing.Color.White;
            this.AddFoodButton.Location = new System.Drawing.Point(384, 4);
            this.AddFoodButton.Name = "AddFoodButton";
            this.AddFoodButton.Size = new System.Drawing.Size(110, 53);
            this.AddFoodButton.TabIndex = 2;
            this.AddFoodButton.Text = "Thêm món";
            this.AddFoodButton.UseVisualStyleBackColor = false;
            this.AddFoodButton.Click += new System.EventHandler(this.AddFoodButton_Click);
            // 
            // FoodComboBox
            // 
            this.FoodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FoodComboBox.BackColor = System.Drawing.Color.White;
            this.FoodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FoodComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FoodComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FoodComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FoodComboBox.FormattingEnabled = true;
            this.FoodComboBox.Location = new System.Drawing.Point(3, 33);
            this.FoodComboBox.Name = "FoodComboBox";
            this.FoodComboBox.Size = new System.Drawing.Size(375, 28);
            this.FoodComboBox.TabIndex = 1;
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryComboBox.BackColor = System.Drawing.Color.White;
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CategoryComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CategoryComboBox.ForeColor = System.Drawing.Color.Black;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(3, 4);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(375, 28);
            this.CategoryComboBox.TabIndex = 0;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // TableFlowLayoutPanel
            // 
            this.TableFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TableFlowLayoutPanel.AutoScroll = true;
            this.TableFlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TableFlowLayoutPanel.Location = new System.Drawing.Point(13, 31);
            this.TableFlowLayoutPanel.Name = "TableFlowLayoutPanel";
            this.TableFlowLayoutPanel.Size = new System.Drawing.Size(349, 550);
            this.TableFlowLayoutPanel.TabIndex = 5;
            this.TableFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TableFlowLayoutPanel_Paint);
            // 
            // TableManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 593);
            this.Controls.Add(this.TableFlowLayoutPanel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "TableManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý quán cà phê";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountNumericUpDown)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FoodCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView BillListView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.NumericUpDown FoodCountNumericUpDown;
        private System.Windows.Forms.Button AddFoodButton;
        private System.Windows.Forms.ComboBox FoodComboBox;
        private System.Windows.Forms.FlowLayoutPanel TableFlowLayoutPanel;
        private System.Windows.Forms.Button SwitchTableButton;
        private System.Windows.Forms.NumericUpDown DiscountNumericUpDown;
        private System.Windows.Forms.Button CheckOutButton;
        private System.Windows.Forms.ComboBox SwitchTableComboBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox TotalPriceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

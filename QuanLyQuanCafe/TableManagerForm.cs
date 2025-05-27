using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.DAO;
using System.Globalization;
using System.Threading;
using System.ComponentModel.Design.Serialization;

namespace QuanLyQuanCafe
{
    public partial class TableManagerForm : Form
    {
        private Table currentTable = null;
        private Button currentTableButton = null;
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public TableManagerForm(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboBoxTable(SwitchTableComboBox);
        }
        #region Method
        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            CategoryComboBox.DataSource = listCategory;
            CategoryComboBox.DisplayMember = "Name";
        }
        void LoadFoodListCategoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(id);
            FoodComboBox.DataSource = listFood;
            FoodComboBox.DisplayMember = "Name";
        }
        void LoadTable()
        {
            TableFlowLayoutPanel.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Margin = new Padding(8),
                    Cursor = Cursors.Hand,
                    Name = "btn" + item.ID
                };

                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.FromArgb(240, 240, 240); 
                        btn.ForeColor = Color.FromArgb(38, 50, 56);    
                        break;
                    default:
                        btn.BackColor = Color.FromArgb(0, 150, 136);  
                        btn.ForeColor = Color.White;                   
                        break;
                }

                // Thêm hiệu ứng hover
                btn.MouseEnter += (sender, e) =>
                {
                    if (item.Status == "Trống")
                        btn.BackColor = Color.FromArgb(224, 224, 224); 
                    else
                        btn.BackColor = Color.FromArgb(0, 137, 123);   
                };

                btn.MouseLeave += (sender, e) =>
                {
                    if (item.Status == "Trống")
                        btn.BackColor = Color.FromArgb(240, 240, 240); 
                    else
                        btn.BackColor = Color.FromArgb(0, 150, 136);   
                };

                TableFlowLayoutPanel.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            BillListView.Items.Clear();
            List<QuanLyQuanCafe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;
            foreach (QuanLyQuanCafe.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                BillListView.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            TotalPriceTextBox.Text = totalPrice.ToString("c", culture);
        }
        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            if (currentTableButton != null)
            {
                ResetButtonColor(currentTableButton);
            }
            Button clickedButton = sender as Button;
            Table table = clickedButton.Tag as Table;
            currentTableButton = clickedButton;
            currentTable = table;
            HighlightSelectedTable(clickedButton, table);
            int tableID = table.ID;
            BillListView.Tag = table;
            ShowBill(tableID);           
        }
        private void HighlightSelectedTable(Button btn, Table table)
        {
            if (table.Status == "Trống")
            {
                btn.BackColor = Color.FromArgb(200, 230, 201); 
                btn.FlatAppearance.BorderColor = Color.FromArgb(0, 150, 136);
                btn.FlatAppearance.BorderSize = 2;
            }
            else
            {
                btn.BackColor = Color.FromArgb(0, 121, 107); 
                btn.FlatAppearance.BorderColor = Color.FromArgb(255, 193, 7); 
                btn.FlatAppearance.BorderSize = 2;
            }
        }
        private void ResetButtonColor(Button btn)
        {
            if (btn != null && btn.Tag is Table table)
            {
               
                if (table.Status == "Trống")
                {
                    btn.BackColor = Color.FromArgb(240, 240, 240); 
                    btn.ForeColor = Color.FromArgb(38, 50, 56);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(0, 150, 136);  
                    btn.ForeColor = Color.White;                   
                }

                btn.FlatAppearance.BorderSize = 0;
                btn.MouseEnter -= TableButton_MouseEnter;
                btn.MouseLeave -= TableButton_MouseLeave;

                btn.MouseEnter += TableButton_MouseEnter;
                btn.MouseLeave += TableButton_MouseLeave;
            }
        }

        private void TableButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentTableButton && btn.Tag is Table table) 
            {
                if (table.Status == "Trống")
                    btn.BackColor = Color.FromArgb(224, 224, 224);
                else
                    btn.BackColor = Color.FromArgb(0, 137, 123);
            }
        }

        private void TableButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentTableButton && btn.Tag is Table table)
            {
                if (table.Status == "Trống")
                    btn.BackColor = Color.FromArgb(240, 240, 240);
                else
                    btn.BackColor = Color.FromArgb(0, 150, 136);
            }
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfileForm accountProfileForm = new AccountProfileForm(LoginAccount);
            accountProfileForm.UpdateAccount += accountProfileForm_UpdateAccount;
            accountProfileForm.ShowDialog();
        }

        private void accountProfileForm_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.loginAccount = LoginAccount;
            adminForm.InsertFood += adminForm_InsertFood;
            adminForm.UpdateFood += adminForm_UpdateFood;
            adminForm.DeleteFood += adminForm_DeleteFood;
            adminForm.ShowDialog();
        }

        private void adminForm_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListCategoryID((CategoryComboBox.SelectedItem as Category).ID);
            if (BillListView.Tag != null)
                ShowBill((BillListView.Tag as Table).ID);
        }
        private void adminForm_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListCategoryID((CategoryComboBox.SelectedItem as Category).ID);
            if (BillListView.Tag != null)
                ShowBill((BillListView.Tag as Table).ID);
            LoadTable();
        }
        private void adminForm_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListCategoryID((CategoryComboBox.SelectedItem as Category).ID);
            if (BillListView.Tag != null)
                ShowBill((BillListView.Tag as Table).ID);
        }
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == null)
            {
                return;
            }
            Category selected = cb.SelectedItem as Category;
            id = selected.ID;
            LoadFoodListCategoryID(id);
        }
        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            Table table = BillListView.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
            }
            int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
            int foodID = (FoodComboBox.SelectedItem as Food).ID;
            int count = (int)FoodCountNumericUpDown.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInforDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillInforDAO.Instance.InsertBillInfo(idBill, foodID, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }
        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            Table table = BillListView.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillByTableID(table.ID);

            if (idBill == -1)
            {
                MessageBox.Show(string.Format("{0} không có hóa đơn cần thanh toán!", table.Name), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int discount = (int)DiscountNumericUpDown.Value;

            // Sử dụng hàm GetTotalPrice mới để tính tổng tiền và giảm giá
            float totalPrice = BillDAO.Instance.GetTotalPrice(idBill);
            float finalTotalPrice = BillDAO.Instance.GetTotalPrice(idBill, discount);

            if (MessageBox.Show(
                string.Format("Bạn có chắc thanh toán hóa đơn cho {0}\nTổng tiền - (Tổng tiền / 100) * Giảm giá\n => {1:N0} - {1:N0}/100 x {2} = {3:N0} VNĐ",
                table.Name, totalPrice, discount, finalTotalPrice),
                "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    // Lấy thông tin người dùng hiện tại
                    string currentUsername = Program.CurrentUser?.UserName ?? "Unknown";

                    // Gọi phương thức CheckOut với tổng tiền đã tính
                    bool success = BillDAO.Instance.CheckOut(idBill, discount, finalTotalPrice, currentUsername);

                    if (success)
                    {
                        ShowBill(table.ID);
                        LoadTable();
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Ghi log lỗi
                    ActivityLogDAO.Instance.LogActivity(
                        Program.CurrentUser?.UserName ?? "Unknown",
                        "Error",
                        $"Lỗi khi thanh toán hóa đơn #{idBill}: {ex.Message}",
                        "Bill",
                        idBill.ToString());
                }
            }
        }


        private void SwitchTableButton_Click(object sender, EventArgs e)
        {
            int id1 = (BillListView.Tag as Table).ID;
            int id2 = (SwitchTableComboBox.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bản {0} qua bàn {1}", (BillListView.Tag as Table).Name, (SwitchTableComboBox.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }

        #endregion

        private void TableFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BillListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TotalPriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace QuanLyQuanCafe
{
    public partial class AdminForm : Form
    {
        BindingSource foodlist = new BindingSource();
        BindingSource categorylist = new BindingSource();
        BindingSource tablelist = new BindingSource();
        BindingSource accountlist = new BindingSource();
        private int currentPage = 1;
        private int totalPages = 0;
        private int pageSize = 10;
        public Account loginAccount;
        public AdminForm()
        {
            InitializeComponent();
            LoadData();
        }
        #region methods
        void LoadData()
        {
            FoodDataGridView.DataSource = foodlist;
            CategoryDataGridView.DataSource = categorylist;
            TableDataGridView.DataSource = tablelist;
            AccountDataGridView.DataSource = accountlist;
            LoadGroupByComboBox();
            LoadDateTimePickerBill();
            LoadDateTimePickerBillInfo();
            LoadDateTimePickerActivityLog();
            LoadListBillByDate(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value);
            LoadListFood();
            LoadCategoryIntoCombobox(FoodCategoryComboBox);
            LoadListCategory();
            LoadListTable();
            LoadListTableAdmin();
            LoadAccount();
            LoadAccountTypeIntoCombobox(AccountTypeComboBox);
            AddFoodBinding();
            AddCategoryBinding();
            AddTableBinding();
            AddAccountBinding();
            InitializeTopFoodReport();

        }
        //REPORT
        private void LoadGroupByComboBox()
        {
            List<KeyValuePair<string, string>> groupOptions = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("DAY", "Theo ngày"),
                new KeyValuePair<string, string>("WEEK", "Theo tháng"),
                new KeyValuePair<string, string>("MONTH", "Theo năm")
            };

            GroupByComboBox.DataSource = new BindingSource(groupOptions, null);
            GroupByComboBox.DisplayMember = "Value";
            GroupByComboBox.ValueMember = "Key";
            GroupByComboBox.SelectedIndex = 0; // Chọn giá trị mặc định
        }
        private void InitializeTopFoodReport()
        {
            // Khởi tạo cho báo cáo TopFood
            TopCountNumericUpDown.Minimum = 1;
            TopCountNumericUpDown.Maximum = 100;
            TopCountNumericUpDown.Value = 10;

            // Khởi tạo ngày cho báo cáo TopFood
            DateTime today = DateTime.Now;
            FoodFromDateDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            FoodToDateDateTimePicker.Value = today;

        }

        // BILL
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            FromDateDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            ToDateDateTimePicker.Value = FromDateDateTimePicker.Value.AddMonths(1).AddDays(-1);

        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            int currentPage = Convert.ToInt32(PageBillTextBox.Text);
            BillDataGridView.DataSource = BillDAO.Instance.GetBillListByDateAndPage(checkIn, checkOut, currentPage);
        }
        //BILL INFO
        void LoadDateTimePickerBillInfo()
        {
            DateTime today = DateTime.Now;
            BillInfoFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            BillInfoToDateTimePicker.Value = BillInfoFromDateTimePicker.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillInfoByDate(DateTime checkIn, DateTime checkOut)
        {
            int currentPage = Convert.ToInt32(PageBillInfoTextBox.Text); // Cần thêm TextBox cho page BillInfo
            BillInfoDataGridView.DataSource = BillInforDAO.Instance.GetBillInfoListByDateAndPage(checkIn, checkOut, currentPage);
        }
        //FOOD
        void LoadListFood()
        {
            foodlist.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddFoodBinding()
        {
            FoodNameTextBox.DataBindings.Add(new Binding("Text", FoodDataGridView.DataSource, "Name", true, DataSourceUpdateMode.Never));
            FoodIdTextBox.DataBindings.Add(new Binding("Text", FoodDataGridView.DataSource, "ID", true, DataSourceUpdateMode.Never));
            FoodPriceNumericUpDown.DataBindings.Add(new Binding("Value", FoodDataGridView.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(name);
            return listfood;
        }

        // DANH MỤC
        void LoadListCategory()
        {
            categorylist.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void AddCategoryBinding()
        {
            CategoryNametextBox.DataBindings.Add(new Binding("Text", CategoryDataGridView.DataSource, "Name", true, DataSourceUpdateMode.Never));
            CategoryIdTextBox.DataBindings.Add(new Binding("Text", CategoryDataGridView.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }

        //BÀN ĂN
        void LoadListTable()
        {
            tablelist.DataSource = TableDAO.Instance.LoadTableList();
        }
        void LoadListTableAdmin()
        {
            tablelist.DataSource = TableDAO.Instance.LoadListAllTable();
        }
        void AddTableBinding()
        {
            TableNameTextBox.DataBindings.Add(new Binding("Text", TableDataGridView.DataSource, "Name", true, DataSourceUpdateMode.Never));
            TableIdTextBox.DataBindings.Add(new Binding("Text", TableDataGridView.DataSource, "ID", true, DataSourceUpdateMode.Never));
            TableStatusComboBox.DataBindings.Add(new Binding("Text", TableDataGridView.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        //Account
        void AddAccountBinding()
        {
            UserNameTextBox.DataBindings.Add(new Binding("Text", AccountDataGridView.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            DisplayNameTextBox.DataBindings.Add(new Binding("Text", AccountDataGridView.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            AccountTypeComboBox.DataBindings.Add(new Binding("SelectedValue", AccountDataGridView.DataSource, "type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountlist.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadAccountTypeIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AccountTypeDAO.Instance.GetAccountTypes();
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }
        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Bạn không được phép thay đổi UserName");
            }

            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa tài khoản này");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }
        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        void RestoreAccount(string userName)
        {
            if (AccountDAO.Instance.RestoreAccount(userName))
            {
                MessageBox.Show("Khôi phục tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Khôi phục tài khoản thất bại");
            }
            LoadAccount();
        }

        //ActivityLog
        void LoadDateTimePickerActivityLog()
        {
            DateTime today = DateTime.Now;
            ActivityLogFromDateTimePicker.Value = new DateTime(today.Year, today.Month, 1);
            ActivityLogToDateTimePicker.Value = ActivityLogFromDateTimePicker.Value.AddMonths(1).AddDays(-1);

        }
        void LoadListActivityLogByDate(DateTime checkIn, DateTime checkOut)
        {
            int currentPage = Convert.ToInt32(PageActivityLogTextBox.Text);
            ActivityLogDataGridView.DataSource = ActivityLogDAO.Instance.GetActivityLogListByDateAndPage(checkIn, checkOut, currentPage);
        }
        #endregion

        #region events
        // THỨC ĂN
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        private void ViewBillButton_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value);
        }
        private void ShowFoodButton_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void FoodIdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (FoodDataGridView.SelectedCells.Count > 0 &&
                FoodDataGridView.SelectedCells[0].OwningRow != null &&
                FoodDataGridView.SelectedCells[0].OwningRow.Cells["CategoryID"] != null &&
                FoodDataGridView.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
                {
                    int id = (int)FoodDataGridView.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    FoodCategoryComboBox.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in FoodCategoryComboBox.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    FoodCategoryComboBox.SelectedIndex = index;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Có lỗi khi truy cập dữ liệu CategoryID!");
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Không thể chuyển đổi giá trị CategoryID sang kiểu số nguyên!");
            }

        }
        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = FoodNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên món ăn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodNameTextBox.Focus();
                    return;
                }

                if (FoodCategoryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodCategoryComboBox.Focus();
                    return;
                }
                int categoryID = (FoodCategoryComboBox.SelectedItem as Category).ID;

                float price = (float)FoodPriceNumericUpDown.Value;
                if (price <= 0)
                {
                    MessageBox.Show("Giá món ăn phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodPriceNumericUpDown.Focus();
                    return;
                }

                bool success = FoodDAO.Instance.InsertFood(name, categoryID, price);
                if (success)
                {
                    MessageBox.Show("Thêm món thành công");
                    LoadListFood();
                    insertFood?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm thức ăn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(FoodIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID món ăn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodIdTextBox.Focus();
                    return;
                }

                string name = FoodNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên món ăn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodNameTextBox.Focus();
                    return;
                }

                if (FoodCategoryComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cho món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodCategoryComboBox.Focus();
                    return;
                }
                int categoryID = (FoodCategoryComboBox.SelectedItem as Category).ID;

                float price = (float)FoodPriceNumericUpDown.Value;
                if (price <= 0)
                {
                    MessageBox.Show("Giá món ăn phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodPriceNumericUpDown.Focus();
                    return;
                }

                bool success = FoodDAO.Instance.UpdateFood(id, name, categoryID, price);
                if (success)
                {
                    MessageBox.Show("Sửa món thành công");
                    LoadListFood();
                    updateFood?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa món");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteFoodbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(FoodIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID món ăn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FoodIdTextBox.Focus();
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool success = FoodDAO.Instance.DeleteFood(id);
                    if (success)
                    {
                        MessageBox.Show("Xóa món thành công");
                        LoadListFood();
                        deleteFood?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa thức ăn");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa món ăn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchFoodButton_Click(object sender, EventArgs e)
        {
            foodlist.DataSource = SearchFoodByName(SearchFoodNameTextBox.Text);
        }

        // DANH MỤC
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        private void ShowCategoryButton_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = CategoryNametextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên danh mục không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CategoryNametextBox.Focus();
                    return;
                }

                if (CategoryDAO.Instance.InsertCategory(name))
                {
                    MessageBox.Show("Thêm danh mục thành công");
                    LoadListCategory();
                    insertCategory?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm danh mục");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(CategoryIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID danh mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CategoryIdTextBox.Focus();
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (CategoryDAO.Instance.DeleteCategory(id))
                    {
                        MessageBox.Show("Xóa danh mục thành công");
                        LoadListCategory();
                        deleteCategory?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa danh mục");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditCategoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(CategoryIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID danh mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CategoryIdTextBox.Focus();
                    return;
                }

                string name = CategoryNametextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên danh mục không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CategoryNametextBox.Focus();
                    return;
                }

                if (CategoryDAO.Instance.UpdateCategory(name, id))
                {
                    MessageBox.Show("Sửa danh mục thành công");
                    LoadListCategory();
                    updateCategory?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa danh mục");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BÀN ĂN
        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            LoadListTableAdmin();
        }
        private void AddTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = TableNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên bàn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableNameTextBox.Focus();
                    return;
                }

                string status = TableStatusComboBox.Text;
                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableStatusComboBox.Focus();
                    return;
                }

                if (TableDAO.Instance.InsertTable(name, status))
                {
                    MessageBox.Show("Thêm bàn thành công");
                    LoadListTable();
                    insertTable?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm bàn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TableIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID bàn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableIdTextBox.Focus();
                    return;
                }

                string name = TableNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Tên bàn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableNameTextBox.Focus();
                    return;
                }

                string status = TableStatusComboBox.Text;
                if (string.IsNullOrEmpty(status))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableStatusComboBox.Focus();
                    return;
                }

                if (TableDAO.Instance.UpdateTable(id, name, status))
                {
                    MessageBox.Show("Sửa bàn thành công");
                    LoadListTable();
                    updateTable?.Invoke(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa bàn");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteTableButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(TableIdTextBox.Text, out int id))
                {
                    MessageBox.Show("ID bàn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TableIdTextBox.Focus();
                    return;
                }

                string status = TableStatusComboBox.Text;

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (TableDAO.Instance.DeleteTable(id, status))
                    {
                        MessageBox.Show("Xóa bàn thành công");
                        LoadListTableAdmin();
                        deleteTable?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa bàn");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Account
        private void ShowAccountButton_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void AddAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserNameTextBox.Focus();
                    return;
                }

                string displayName = DisplayNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(displayName))
                {
                    MessageBox.Show("Tên hiển thị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisplayNameTextBox.Focus();
                    return;
                }

                if (AccountTypeComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AccountTypeComboBox.Focus();
                    return;
                }

                int type = AccountTypeComboBox.SelectedIndex;

                AddAccount(userName, displayName, type);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserNameTextBox.Focus();
                    return;
                }

                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DeleteAccount(userName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserNameTextBox.Focus();
                    return;
                }

                string displayName = DisplayNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(displayName))
                {
                    MessageBox.Show("Tên hiển thị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DisplayNameTextBox.Focus();
                    return;
                }

                if (AccountTypeComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại tài khoản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AccountTypeComboBox.Focus();
                    return;
                }

                int type = AccountTypeComboBox.SelectedIndex;

                EditAccount(userName, displayName, type);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetPassWordButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserNameTextBox.Focus();
                    return;
                }
                ResetPass(userName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RestoreAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = UserNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UserNameTextBox.Focus();
                    return;
                }
                RestoreAccount(userName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khôi phục tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Page
        private void FirstBillPageButton_Click(object sender, EventArgs e)
        {
            PageBillTextBox.Text = "1";
        }
        private void LastBillPageButton_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            PageBillTextBox.Text = lastPage.ToString();
        }
        private void PageBillTextBox_TextChanged(object sender, EventArgs e)
        {
            BillDataGridView.DataSource = BillDAO.Instance.GetBillListByDateAndPage(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value, Convert.ToInt32(PageBillTextBox.Text));
        }
        private void PreviousBillPageButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageBillTextBox.Text);

            if (page > 1)
                page--;

            PageBillTextBox.Text = page.ToString();
        }
        private void AfterBillPageButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageBillTextBox.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value);

            if (page < sumRecord)
                page++;

            PageBillTextBox.Text = page.ToString();
        }

        // REPORT


        // RevenueReport
        private void LoadRevenueReport(DateTime fromDate, DateTime toDate, string groupBy, string reportTitle)

        {
            try
            {
                string connectionSTR = @"Data Source=localhost;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionSTR))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("USP_ReportRevenueByTime", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    command.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.DateTime).Value = toDate;
                    command.Parameters.Add("@groupBy", SqlDbType.NVarChar).Value = groupBy;

                    // Tạo adapter và dataset
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Kiểm tra xem có dữ liệu không
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này!");
                        return;
                    }

                    // Quan trọng: Đặt tên của ReportDataSource phải khớp với tên trong báo cáo RDLC
                    ReportDataSource reportDataSource = new ReportDataSource("USP_ReportRevenueByTime", dataTable);

                    // Xóa nguồn dữ liệu cũ
                    RevenueReportViewer.LocalReport.DataSources.Clear();

                    // Thêm nguồn dữ liệu mới
                    RevenueReportViewer.LocalReport.DataSources.Add(reportDataSource);
                    ReportParameter[] parameters = new ReportParameter[]
{
    new ReportParameter("ReportTitle", reportTitle)
};
                    RevenueReportViewer.LocalReport.SetParameters(parameters);

                    // Cập nhật báo cáo
                    RevenueReportViewer.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message);
            }
        }
        private void GenerateRevenueReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = RevenueFromDateDateTimePicker.Value;
                DateTime toDate = RevenueToDateDateTimePicker.Value;

                // Kiểm tra ngày hợp lệ
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc!");
                    return;
                }

                string groupBy = "day"; // Giá trị mặc định
                if (GroupByComboBox.SelectedValue != null)
                {
                    groupBy = GroupByComboBox.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Không có tùy chọn nhóm được chọn. Sử dụng giá trị mặc định 'Theo ngày'.");
                }

                string reportTitle = "";
                switch (groupBy.ToUpper())
                {
                    case "DAY":
                        reportTitle = $"BÁO CÁO DOANH THU: {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}";
                        break;
                    case "WEEK":
                        CultureInfo viCulture = new CultureInfo("vi-VN");
                        reportTitle = $"DOANH THU THÁNG {fromDate.ToString("M yyyy", viCulture).ToUpper()}";

                        break;
                    case "MONTH":
                        reportTitle = $"BÁO CÁO DOANH THU NĂM {fromDate:yyyy}";
                        break;
                    default:
                        reportTitle = "BÁO CÁO DOANH THU";
                        break;
                }


                LoadRevenueReport(fromDate, toDate, groupBy, reportTitle);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message);
            }

        }



        // TopFoodReport
        private void LoadTopFoodReport(DateTime fromDate, DateTime toDate, int topCount)
        {
            try
            {
                // Kiểm tra đường dẫn báo cáo
                string reportPath = Path.Combine(Application.StartupPath, "TopFoodReport.rdlc");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo: {reportPath}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập đường dẫn báo cáo
                try
                {
                    TopFoodReportViewer.LocalReport.ReportPath = reportPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thiết lập đường dẫn báo cáo: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra cấu trúc báo cáo
                try
                {
                    string[] dataSetNames = TopFoodReportViewer.LocalReport.GetDataSourceNames().ToArray();
                    if (dataSetNames.Length == 0)
                    {
                        MessageBox.Show("Báo cáo không có định nghĩa DataSet nào. Vui lòng kiểm tra file RDLC.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi kiểm tra cấu trúc báo cáo: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Tiếp tục thực hiện vì có thể không phải lỗi nghiêm trọng
                }

                string connectionSTR = @"Data Source=localhost;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionSTR))
                    {
                        try
                        {
                            connection.Open();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            SqlCommand command = new SqlCommand("USP_ReportTopSellingFood", connection);
                            command.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số
                            command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                            command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                            command.Parameters.Add("@topCount", SqlDbType.Int).Value = topCount;

                            // Tạo adapter và dataset
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();

                            try
                            {
                                adapter.Fill(dataTable);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show($"Lỗi khi thực thi stored procedure: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Kiểm tra xem có dữ liệu không
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Không có dữ liệu món ăn bán chạy trong khoảng thời gian này!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            try
                            {
                                // Thêm tham số báo cáo để hiển thị thông tin lọc
                                List<ReportParameter> parameters = new List<ReportParameter>();

                                // Chỉ thêm tham số nếu tồn tại trong báo cáo
                                if (TopFoodReportViewer.LocalReport.GetParameters().Any(p => p.Name == "FromDate"))
                                    parameters.Add(new ReportParameter("FromDate", fromDate.ToString("dd/MM/yyyy")));

                                if (TopFoodReportViewer.LocalReport.GetParameters().Any(p => p.Name == "ToDate"))
                                    parameters.Add(new ReportParameter("ToDate", toDate.ToString("dd/MM/yyyy")));

                                if (TopFoodReportViewer.LocalReport.GetParameters().Any(p => p.Name == "TopCount"))
                                    parameters.Add(new ReportParameter("TopCount", topCount.ToString()));

                                if (parameters.Count > 0)
                                {
                                    TopFoodReportViewer.LocalReport.SetParameters(parameters);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Bỏ qua lỗi tham số báo cáo và tiếp tục
                            }

                            try
                            {
                                // Lấy tên DataSet từ báo cáo
                                string[] dataSetNames = TopFoodReportViewer.LocalReport.GetDataSourceNames().ToArray();
                                string dataSetName = dataSetNames.Length > 0 ? dataSetNames[0] : "USP_ReportTopSellingFood";

                                // Quan trọng: Đặt tên của ReportDataSource phải khớp với tên trong báo cáo RDLC
                                ReportDataSource reportDataSource = new ReportDataSource(dataSetName, dataTable);

                                // Xóa nguồn dữ liệu cũ
                                TopFoodReportViewer.LocalReport.DataSources.Clear();

                                // Thêm nguồn dữ liệu mới
                                TopFoodReportViewer.LocalReport.DataSources.Add(reportDataSource);

                                // Cập nhật báo cáo
                                TopFoodReportViewer.RefreshReport();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi cập nhật báo cáo: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tạo command: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo kết nối: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tổng quát khi tạo báo cáo món ăn bán chạy: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateFoodReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = FoodFromDateDateTimePicker.Value;
                DateTime toDate = FoodToDateDateTimePicker.Value;

                // Kiểm tra ngày hợp lệ
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị con trỏ đang xử lý
                Cursor = Cursors.WaitCursor;

                int topCount = (int)TopCountNumericUpDown.Value;

                LoadTopFoodReport(fromDate, toDate, topCount);

                // Khôi phục con trỏ
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo món ăn bán chạy: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        //FoodAssociationReport

        private void MinSupportTrackBar_ValueChanged(object sender, EventArgs e)
        {
            MinSupportValueLable.Text = MinSupportTrackBar.Value.ToString() + "%";
        }

        private void MinConfidenceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            MinConfidenceValueLabel.Text = MinConfidenceTrackBar.Value.ToString() + "%";
        }
        private void LoadFoodAssociationReport(DateTime fromDate, DateTime toDate, float minSupport, float minConfidence)
        {
            try
            {
                // Kiểm tra đường dẫn báo cáo
                string reportPath = Path.Combine(Application.StartupPath, "FoodAssociationReport.rdlc");
                if (!File.Exists(reportPath))
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo: {reportPath}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập đường dẫn báo cáo
                try
                {
                    FoodAssociationReportViewer.LocalReport.ReportPath = reportPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thiết lập đường dẫn báo cáo: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionSTR = @"Data Source=localhost;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionSTR))
                    {
                        try
                        {
                            connection.Open();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            SqlCommand command = new SqlCommand("USP_ReportFoodAssociation", connection);
                            command.CommandType = CommandType.StoredProcedure;

                            // Thêm các tham số
                            command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                            command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                            command.Parameters.Add("@minSupport", SqlDbType.Float).Value = minSupport;
                            command.Parameters.Add("@minConfidence", SqlDbType.Float).Value = minConfidence;

                            // Tạo adapter và dataset
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();

                            try
                            {
                                adapter.Fill(dataTable);
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show($"Lỗi khi thực thi stored procedure: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            // Kiểm tra xem có dữ liệu không
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Không có dữ liệu kết hợp món ăn trong khoảng thời gian này hoặc với các ngưỡng đã chọn!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            try
                            {
                                // Thêm tham số báo cáo để hiển thị thông tin lọc
                                List<ReportParameter> parameters = new List<ReportParameter>();

                                // Chỉ thêm tham số nếu tồn tại trong báo cáo
                                if (FoodAssociationReportViewer.LocalReport.GetParameters().Any(p => p.Name == "FromDate"))
                                    parameters.Add(new ReportParameter("FromDate", fromDate.ToString("dd/MM/yyyy")));

                                if (FoodAssociationReportViewer.LocalReport.GetParameters().Any(p => p.Name == "ToDate"))
                                    parameters.Add(new ReportParameter("ToDate", toDate.ToString("dd/MM/yyyy")));

                                if (FoodAssociationReportViewer.LocalReport.GetParameters().Any(p => p.Name == "MinSupport"))
                                    parameters.Add(new ReportParameter("MinSupport", minSupport.ToString("P1")));

                                if (FoodAssociationReportViewer.LocalReport.GetParameters().Any(p => p.Name == "MinConfidence"))
                                    parameters.Add(new ReportParameter("MinConfidence", minConfidence.ToString("P1")));

                                if (parameters.Count > 0)
                                {
                                    FoodAssociationReportViewer.LocalReport.SetParameters(parameters);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Bỏ qua lỗi tham số báo cáo và tiếp tục
                            }

                            try
                            {
                                // Lấy tên DataSet từ báo cáo
                                string[] dataSetNames = FoodAssociationReportViewer.LocalReport.GetDataSourceNames().ToArray();
                                string dataSetName = dataSetNames.Length > 0 ? dataSetNames[0] : "USP_ReportFoodAssociation";

                                // Quan trọng: Đặt tên của ReportDataSource phải khớp với tên trong báo cáo RDLC
                                ReportDataSource reportDataSource = new ReportDataSource(dataSetName, dataTable);

                                // Xóa nguồn dữ liệu cũ
                                FoodAssociationReportViewer.LocalReport.DataSources.Clear();

                                // Thêm nguồn dữ liệu mới
                                FoodAssociationReportViewer.LocalReport.DataSources.Add(reportDataSource);

                                // Cập nhật báo cáo
                                FoodAssociationReportViewer.RefreshReport();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi cập nhật báo cáo: {ex.Message}",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi tạo command: {ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tạo kết nối: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tổng quát khi tạo báo cáo kết hợp món ăn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateFoodAssociationReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = FoodAssociationFromDateDateTimePicker.Value;
                DateTime toDate = FoodAssociationToDateDateTimePicker.Value;

                // Kiểm tra ngày hợp lệ
                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không thể sau ngày kết thúc!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Hiển thị con trỏ đang xử lý
                Cursor = Cursors.WaitCursor;

                // Lấy giá trị từ TrackBar và chuyển đổi thành tỷ lệ (0.0 - 1.0)
                float minSupport = MinSupportTrackBar.Value / 100f;
                float minConfidence = MinConfidenceTrackBar.Value / 100f;

                LoadFoodAssociationReport(fromDate, toDate, minSupport, minConfidence);

                // Khôi phục con trỏ
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo kết hợp món ăn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }
        // BillInfo
        private void BillInfoShowButton_Click(object sender, EventArgs e)
        {
            LoadListBillInfoByDate(FromDateDateTimePicker.Value, ToDateDateTimePicker.Value);
        }
        private void FirstBillInfoPageButton_Click(object sender, EventArgs e)
        {
                PageBillInfoTextBox.Text = "1";
        }
        private void PreBillInfoPageButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageBillInfoTextBox.Text);

            if (page > 1)
                page--;

            PageBillInfoTextBox.Text = page.ToString();
        }
        private void NextBillInfoPageButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageBillInfoTextBox.Text);
            int sumRecord = BillInforDAO.Instance.GetNumBillInfoListByDate(BillInfoFromDateTimePicker.Value, BillInfoToDateTimePicker.Value);

            if (page < sumRecord)
                page++;

            PageBillInfoTextBox.Text = page.ToString();
        }
        private void LastBillInfoPageButton_Click(object sender, EventArgs e)
        {
            int sumRecord = BillInforDAO.Instance.GetNumBillInfoListByDate(BillInfoFromDateTimePicker.Value, BillInfoToDateTimePicker.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            PageBillInfoTextBox.Text = lastPage.ToString();
        }
        private void PageBillInfoTextBox_TextChanged(object sender, EventArgs e)
        {
            BillInfoDataGridView.DataSource = BillInforDAO.Instance.GetBillInfoListByDateAndPage(BillInfoFromDateTimePicker.Value, BillInfoToDateTimePicker.Value, Convert.ToInt32(PageBillInfoTextBox.Text));
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            this.RevenueReportViewer.RefreshReport();
            this.TopFoodReportViewer.RefreshReport();
            this.FoodAssociationReportViewer.RefreshReport();
        }

        //ActivityLog
        private void FirstPageLogButton_Click(object sender, EventArgs e)
        {
            PageActivityLogTextBox.Text = "1";
        }

        private void PrePageLogButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageActivityLogTextBox.Text);

            if (page > 1)
                page--;

            PageActivityLogTextBox.Text = page.ToString();
        }

        private void NextPageLogButton_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(PageActivityLogTextBox.Text);
            int sumRecord = ActivityLogDAO.Instance.GetNumActivityLogListByDate(ActivityLogFromDateTimePicker.Value, ActivityLogToDateTimePicker.Value);

            int totalPages = sumRecord / 10;
            if (sumRecord % 10 != 0)
                totalPages++;

            if (page < totalPages)
                page++;

            PageActivityLogTextBox.Text = page.ToString();
        }

        private void LastPageLogButton_Click(object sender, EventArgs e)
        {
            int sumRecord = ActivityLogDAO.Instance.GetNumActivityLogListByDate(ActivityLogFromDateTimePicker.Value, ActivityLogToDateTimePicker.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            PageActivityLogTextBox.Text = lastPage.ToString();
        }

        private void PageActivityLogTextBox_TextChanged(object sender, EventArgs e)
        {
            ActivityLogDataGridView.DataSource = ActivityLogDAO.Instance.GetActivityLogListByDateAndPage(ActivityLogFromDateTimePicker.Value, ActivityLogToDateTimePicker.Value, Convert.ToInt32(PageBillInfoTextBox.Text));
        }

        private void LogShowButton_Click(object sender, EventArgs e)
        {
            LoadListActivityLogByDate(ActivityLogFromDateTimePicker.Value, ActivityLogToDateTimePicker.Value);
        }
        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM Food WHERE idCategory = " + id + " AND isDeleted = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM Food ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food(name, idCategory, price, isDeleted) VALUES (N'{0}', {1}, {2}, 0)", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            // Thay đổi thành cập nhật trường isDeleted thay vì xóa thật sự
            string query = string.Format("UPDATE dbo.Food SET isDeleted = 1 WHERE id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%' AND isDeleted = 0", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        // Thêm phương thức để khôi phục món ăn đã xóa
        public bool RestoreFood(int idFood)
        {
            string query = string.Format("UPDATE dbo.Food SET isDeleted = 0 WHERE id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        // Thêm phương thức để lấy danh sách món ăn đã xóa
        public List<Food> GetListDeletedFood()
        {
            List<Food> list = new List<Food>();
            string query = "SELECT * FROM Food WHERE isDeleted = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}

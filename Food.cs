using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        private int iD;
        private string name;
        private int categoryID;
        private float price;
        private bool isDeleted;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
        public bool IsDeleted { get => isDeleted; set => isDeleted = value; }

        public Food(int id, string name, int categoryID, float price, bool isDeleted = false)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
            this.IsDeleted = isDeleted;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.IsDeleted = row["isDeleted"] != DBNull.Value && (bool)row["isDeleted"];
        }
    }
}

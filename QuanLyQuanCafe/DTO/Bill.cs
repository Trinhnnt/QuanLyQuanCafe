using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int discount;
        private decimal totalPrice;
        public int ID { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }

        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount, decimal totalPrice)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
            this.TotalPrice = totalPrice;

        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];

            if (row["dateCheckOut"] != DBNull.Value)
                this.DateCheckOut = Convert.ToDateTime(row["dateCheckOut"]);
            else
                this.DateCheckOut = null;

            this.Status = (int)row["status"];

            if (row["discount"].ToString()!="")
                this.Discount = (int)row["discount"];
            if (row["totalPrice"].ToString() != "")
                this.TotalPrice = Convert.ToDecimal(row["totalPrice"]);
            else
                this.TotalPrice = 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; } 
        }
        private BillDAO() { }

        /// <summary>
        /// Thành công: bill ID
        /// Thất bại -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable =" + id + "AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @idTable", new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
        public bool CheckOut(int id, int discount, float totalPrice, string username)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1, discount = " + discount + ", totalPrice = " + totalPrice + " WHERE id= " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { discount, totalPrice, id });

            if (result > 0)
            {
                // Ghi log thanh toán hóa đơn
                ActivityLogDAO.Instance.LogActivity(
                    username,
                    "CheckOut",
                    $"Thanh toán hóa đơn #{id} với tổng tiền {totalPrice:N0} VND, giảm giá {discount}%",
                    "Bill",
                    id.ToString());
            }

            return result > 0;
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });
        }
        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public float GetTotalPrice(int billID, int discount = 0)
        {
            string query = @"SELECT SUM(bi.count * f.price) 
                   FROM BillInfo AS bi, Food AS f 
                   WHERE bi.idBill = @billID AND bi.idFood = f.id";

            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { billID });

            float totalPrice = result == DBNull.Value ? 0 : Convert.ToSingle(result);

            // Áp dụng giảm giá (nếu có)
            if (discount > 0)
            {
                totalPrice = totalPrice - (totalPrice / 100 * discount);
            }

            return totalPrice;
        }
    }
}

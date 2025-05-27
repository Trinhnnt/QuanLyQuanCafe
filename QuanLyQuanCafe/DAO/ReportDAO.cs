using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance;

        public static ReportDAO Instance
        {
            get { if (instance == null) instance = new ReportDAO(); return ReportDAO.instance; }
            private set { ReportDAO.instance = value; }
        }

        private ReportDAO() { }

        public List<RevenueReportDTO> GetRevenueByDate(DateTime fromDate, DateTime toDate, string groupBy)
        {
            List<RevenueReportDTO> result = new List<RevenueReportDTO>();

            string query = "EXEC USP_ReportRevenueByTime @fromDate , @toDate , @groupBy";

            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { fromDate, toDate, groupBy });

            foreach (DataRow row in data.Rows)
            {
                DateTime timePoint = (DateTime)row["TimePoint"];
                double revenue = Convert.ToDouble(row["Revenue"]);
                int billCount = Convert.ToInt32(row["BillCount"]);
                double averageBillValue = Convert.ToDouble(row["AverageBillValue"]);

                result.Add(new RevenueReportDTO(timePoint, revenue, billCount, averageBillValue));
            }

            return result;
        }

        public List<TopFoodReportDTO> GetTopSellingFood(DateTime fromDate, DateTime toDate, int topCount = 10)
        {
            List<TopFoodReportDTO> list = new List<TopFoodReportDTO>();

            string query = "EXEC USP_ReportTopSellingFood @fromDate , @toDate , @topCount";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new object[] { fromDate, toDate, topCount });

            foreach (DataRow row in data.Rows)
            {
                TopFoodReportDTO report = new TopFoodReportDTO
                {
                    FoodName = row["FoodName"].ToString(),
                    CategoryName = row["CategoryName"].ToString(),
                    TotalQuantity = Convert.ToInt32(row["TotalQuantity"]),
                    UnitPrice = Convert.ToDouble(row["UnitPrice"]),
                    TotalRevenue = Convert.ToDouble(row["TotalRevenue"])
                };
                list.Add(report);
            }

            return list;
        }

        public List<TableUsageReportDTO> GetTableUsageReport(DateTime fromDate, DateTime toDate)
        {
            List<TableUsageReportDTO> list = new List<TableUsageReportDTO>();

            string query = "EXEC USP_ReportTableUsage @fromDate , @toDate";
            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                new object[] { fromDate, toDate });

            foreach (DataRow row in data.Rows)
            {
                TableUsageReportDTO report = new TableUsageReportDTO
                {
                    TableID = Convert.ToInt32(row["TableID"]),
                    TableName = row["TableName"].ToString(),
                    BillCount = Convert.ToInt32(row["BillCount"]),
                    TotalRevenue = Convert.ToDouble(row["TotalRevenue"]),
                    AverageRevenue = Convert.ToDouble(row["AverageRevenue"]),
                    TotalMinutesUsed = Convert.ToInt32(row["TotalMinutesUsed"]),
                    AverageMinutesPerBill = Convert.ToDouble(row["AverageMinutesPerBill"])
                };
                list.Add(report);
            }

            return list;
        }
    }
}

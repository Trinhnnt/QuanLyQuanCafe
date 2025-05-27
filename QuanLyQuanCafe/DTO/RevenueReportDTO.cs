using System;

namespace QuanLyQuanCafe.DTO
{
    public class RevenueReportDTO
    {
        public DateTime TimePoint { get; set; }
        public double Revenue { get; set; }
        public int BillCount { get; set; }
        public double AverageBillValue { get; set; }
        public RevenueReportDTO(DateTime timePoint, double revenue, int billCount, double averageBillValue)
        {
            TimePoint = timePoint;
            Revenue = revenue;
            BillCount = billCount;
            AverageBillValue = averageBillValue;
        }
    }
}

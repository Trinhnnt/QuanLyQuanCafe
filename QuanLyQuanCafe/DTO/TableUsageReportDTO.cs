namespace QuanLyQuanCafe.DTO
{
    public class TableUsageReportDTO
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int BillCount { get; set; }
        public double TotalRevenue { get; set; }
        public double AverageRevenue { get; set; }
        public int TotalMinutesUsed { get; set; }
        public double AverageMinutesPerBill { get; set; }
    }
}

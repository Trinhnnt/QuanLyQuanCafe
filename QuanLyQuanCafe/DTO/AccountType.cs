using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class AccountType
    {
        private int id;
        private string name;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public AccountType(int id, string name, string description)
        {
            this.ID = id;
            this.Name = name;
        }

        public AccountType(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
        }
    }
}

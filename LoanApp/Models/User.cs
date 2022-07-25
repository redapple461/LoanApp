namespace LoanApp.Models
{
    public class User : ICloneable
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ContactList { get; set; }

        public string Password { get; set; }

        public int TotalLoan { get; set; }

        public object Clone() => MemberwiseClone();
    }
}

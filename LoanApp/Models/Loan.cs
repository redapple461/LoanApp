namespace LoanApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
    }
}

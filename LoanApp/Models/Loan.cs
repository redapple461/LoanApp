namespace LoanApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public int WhomUserId { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}

namespace LoanApp.Models
{
    public class LoanGetModel
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public string WhomUserId { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}

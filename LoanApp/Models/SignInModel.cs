using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Incorrect phone provided")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Incorrect password provided")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models

{
    public class SignUpModel
    {
        [Required(ErrorMessage = "User Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password are not the same")]
        public string ConfirmPassword { get; set; }
    }
}

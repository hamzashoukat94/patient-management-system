using System.ComponentModel.DataAnnotations;

namespace Application.ApplicationLayer.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(=.*[!@#$%^&*()\-_=+{}[\]:""|;'<>,./])(=.*\d)(=.*[A-Z]).+$",
        ErrorMessage = "Password must contain 1 non-alphanumeric, 1 digit, and 1 uppercase letter.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

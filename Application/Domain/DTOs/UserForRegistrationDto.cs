using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.DTOs
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[!@#$%^&*()\-_=+{}[\]:""|;'<>,.?/])(?=.*\d)(?=.*[A-Z]).+$",
        ErrorMessage = "Password must contain 1 non-alphanumeric, 1 digit, and 1 uppercase letter.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [RegularExpression(@"^(?=.*[!@#$%^&*()\-_=+{}[\]:""|;'<>,.?/])(?=.*\d)(?=.*[A-Z]).+$",
       ErrorMessage = "Confirm Password must contain 1 non-alphanumeric, 1 digit, and 1 uppercase letter.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}

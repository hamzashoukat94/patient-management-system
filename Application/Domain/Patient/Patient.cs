using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Domain.Patient
{
    public class Patient
    {

        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Contact { get; set; }

        public string? Address { get; set; }
    }
}

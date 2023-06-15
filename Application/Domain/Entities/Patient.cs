using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Application.Domain.Entities
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[0-9]{11}")]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

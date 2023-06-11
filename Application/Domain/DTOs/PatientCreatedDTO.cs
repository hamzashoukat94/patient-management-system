using System.ComponentModel.DataAnnotations;

namespace Application.Domain.DTOs
{
    public class PatientCreatedDTO
    {
        public int? Id { get; set; }
    }

    public class PatientCreationDTO
    {
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Contact is required.")]
        [Phone]
        public string? Contact { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
    }

    public class PatientDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Contact is required.")]
        [Phone]
        public string? Contact { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }
    }
}

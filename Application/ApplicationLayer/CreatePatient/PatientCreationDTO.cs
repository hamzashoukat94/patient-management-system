using System.ComponentModel.DataAnnotations;

namespace Application.ApplicationLayer.CreatePatient
{
    public class PatientCreationDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }
}

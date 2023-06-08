using System.ComponentModel.DataAnnotations;

namespace Application.Domain.DTOs
{
    public class PatientCreatedDTO
    {
        public int Id { get; set; }

    }

    public class PatientCreationDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Address { get; set; }
    }

    public class PatientDTO
    {

    }

    public class PatientUpdatedDTO
    {

    }

    public class PatientUpdateDTO
    {

    }


}

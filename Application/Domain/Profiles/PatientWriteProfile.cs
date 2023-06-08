using Application.Domain.DTOs;
using AutoMapper;

namespace Application.Domain.Profiles
{
    public class PatientWriteProfile : Profile
    {
        public PatientWriteProfile()
        {
            CreateMap<PatientCreationDTO, Patient>();
            CreateMap<PatientUpdateDTO, Patient>();
            CreateMap<Patient, PatientUpdatedDTO>();
            CreateMap<Patient, PatientCreatedDTO>();
        }
    }
}

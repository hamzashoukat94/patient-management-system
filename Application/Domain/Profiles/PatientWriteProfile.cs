using Application.Domain.DTOs;
using AutoMapper;

namespace Application.Domain.Profiles
{
    public class PatientWriteProfile : Profile
    {
        public PatientWriteProfile()
        {
            CreateMap<PatientCreationDTO, Patient>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Patient, PatientCreatedDTO>();
        }
    }
}

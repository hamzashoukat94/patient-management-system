using Application.Domain.DTOs;
using Application.Domain;
using AutoMapper;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
               .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email)); 

            CreateMap<Patient, PatientDto>();

            CreateMap<PatientCreationDTO, Patient>();

            CreateMap<PatientDto, Patient>();

            CreateMap<Patient, PatientCreatedDTO>();
        }
    }
}

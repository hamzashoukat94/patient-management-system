using AutoMapper;
using Application.ApplicationLayer.Account;
using Application.ApplicationLayer.Patients;
using Application.Domain.Entities;
using Application.ApplicationLayer.CreatePatient;

namespace Application.ApplicationLayer
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

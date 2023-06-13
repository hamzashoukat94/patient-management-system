using AutoMapper;
using Application.ApplicationLayer.Account;
using Application.Domain.User;
using Application.Domain.Patient;
using Application.ApplicationLayer.Patients;

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

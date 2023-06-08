using Application.Domain.DTOs;
using AutoMapper;

namespace Application.Domain.Profiles
{
    public class PatientReadProfile : Profile
    {
        public PatientReadProfile() 
        {
            CreateMap<Patient, PatientDTO>();
        }
    }
}

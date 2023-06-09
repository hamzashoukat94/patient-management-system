using Application.Domain;
using Application.Domain.DTOs;
using AutoMapper;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public PatientCreatedDTO CreatePatientRecord(PatientCreationDTO patientCreationDTO)
        {
            var patient = _mapper.Map<Patient>(patientCreationDTO);

            return new PatientCreatedDTO()
            {
                Id = _patientRepository.CreatePatient(patient).Id
            };
        }

        public bool Delete(int patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId);

            if (patient == null)
            {
                return false;
            }

            return _patientRepository.Delete(patient);
        }

        public IEnumerable<PatientDTO> GetAllPatients()
        {
           return _patientRepository.GetAllPatients().Select(patient => _mapper.Map<PatientDTO>(patient));
        }

        public PatientDTO? GetPatientById(int patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId);

            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientDTO>(patient);
        }

        public bool UpdatePatientRecord(PatientDTO patientUpdateDTO)
        {
            return _patientRepository.UpdatePatientRecord(_mapper.Map<Patient>(patientUpdateDTO));
        }
    }
}

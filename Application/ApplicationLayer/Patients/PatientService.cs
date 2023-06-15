using Application.ApplicationLayer.CreatePatient;
using Application.Domain;
using Application.Domain.Entities;
using AutoMapper;

namespace Application.ApplicationLayer.Patients
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

        public IEnumerable<PatientDto> GetAllPatients()
        {
            var allPatientDtos = _patientRepository.GetAllPatients();

            return _mapper.Map<IEnumerable<PatientDto>>(allPatientDtos);
        }

        public PatientDto? GetPatientById(int patientId)
        {
            var patient = _patientRepository.GetPatientById(patientId);

            if (patient == null)
            {
                return null;
            }

            return _mapper.Map<PatientDto>(patient);
        }

        public bool UpdatePatientRecord(PatientDto patientUpdateDTO)
        {
            return _patientRepository.UpdatePatientRecord(_mapper.Map<Patient>(patientUpdateDTO));
        }
    }
}

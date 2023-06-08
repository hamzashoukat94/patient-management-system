using Application.Domain.DTOs;

namespace Application.Domain
{
    public interface IPatientService
    {
        /// <summary>
        /// Create Patient method
        /// </summary>
        /// <param name="patientCreationDTO">Patient record data transfer objects</param>
        /// <returns></returns>
        PatientCreatedDTO CreatePatientRecord(PatientCreationDTO patientCreationDTO);

        /// <summary>
        /// Get Patient by ID
        /// </summary>
        /// <param name="patientId">Patient Id</param>
        /// <returns>Patient data transfer object</returns>
        PatientDTO? GetPatientById(int patientId);

        /// <summary>
        /// Get all the patients in the system
        /// </summary>
        /// <returns></returns>
        IEnumerable<PatientDTO> GetAllPatients();

        /// <summary>
        /// Update patient record
        /// </summary>
        /// <param name="patientUpdateDTO">update patient data transfer object</param>
        /// <returns>Updated patient record</returns>
        bool UpdatePatientRecord(PatientUpdateDTO patientUpdateDTO);

        /// <summary>
        /// Delete the patient record
        /// </summary>
        /// <param name="patientId"></param>
        bool Delete(int patientId);
    }
}

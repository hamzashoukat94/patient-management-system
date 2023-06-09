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
        /// Update Patient record
        /// </summary>
        /// <param name="patientDTO">patient data transfer object</param>
        /// <returns></returns>
        bool UpdatePatientRecord(PatientDTO patientDTO);

        /// <summary>
        /// Delete the patient record
        /// </summary>
        /// <param name="patientId"></param>
        bool Delete(int patientId);
    }
}

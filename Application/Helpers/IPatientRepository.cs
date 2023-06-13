using Application.Domain;
using Application.Domain.Patient;

namespace Application.Helpers
{
    public interface IPatientRepository
    {
        Patient? GetPatientById(int patientId);
        IEnumerable<Patient> GetAllPatients();
        Patient CreatePatient(Patient patient);
        bool UpdatePatientRecord(Patient patient);
        bool Delete(Patient patient);
    }
}

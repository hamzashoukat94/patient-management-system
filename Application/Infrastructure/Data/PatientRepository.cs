using Application.Domain;

namespace Application.Infrastructure.Data
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Patient CreatePatient(Patient patient)
        {
            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();
            return patient;
        }

        public bool Delete(Patient patient)
        {
            _dbContext.Remove(patient);
            _dbContext.SaveChanges();
            return true;    
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _dbContext.Patients;
        }

        public Patient? GetPatientById(int patientId)
        {
            return _dbContext.Patients?.FirstOrDefault(patient => patient.Id == patientId);
        }

        public bool UpdatePatientRecord(Patient patient)
        {
            _dbContext.Patients.Update(patient);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

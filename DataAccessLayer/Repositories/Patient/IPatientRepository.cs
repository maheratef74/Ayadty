namespace DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Entities;
public interface IPatientRepository
{
    Task<Patient?> GetById(int patientId);
    Task Add(Patient patient);
    Task SaveChanges();
}
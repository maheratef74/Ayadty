namespace DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Entities;
public interface IPatientRepository
{
    Task<Patient?> GetById(string patientId);
    Task<Patient?> GetPatientByPhoneNUmber(string phoneNumber);
    Task Update(Patient updatedpatient);
    Task SaveChanges();
}

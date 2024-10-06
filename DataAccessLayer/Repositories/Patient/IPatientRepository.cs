using BusinessLogicLayer.DTOs.HelperClass;

namespace DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Entities;

    
public interface IPatientRepository
{
    Task<Patient?> GetById(string patientId);
    Task<Patient?> GetPatientByPhoneNUmber(string phoneNumber);
    Task Update(Patient updatedpatient);
    Task<List<Patient>> GetPatientsByName(string searchTerm);
    Task<List<Patient>> GetAllPatients();
    Task<PaginatedList<Patient>> GetAllPatients(int pageNumber, int pageSize);
    Task Delete(string patientId);
    Task SaveChanges();
}

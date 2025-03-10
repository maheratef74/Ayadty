using BusinessLogicLayer.DTOs.HelperClass;
using DataAccessLayer.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _appDbContext;
    public PatientRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Patient?> GetById(string patientId)
    {
        var patient = await _appDbContext.Users
            .OfType<Patient>()
            .FirstOrDefaultAsync(p => p.Id == patientId);

        return patient;
    }

    public async Task<Patient?> GetPatientByPhoneNUmber(string phoneNumber)
    {
        var patient = await _appDbContext.Users
            .OfType<Patient>()
            .FirstOrDefaultAsync(p => p.Phone == phoneNumber);

        return patient;
    }

    public async Task Update(Patient updatedpatient)
    {
        var patient = await _appDbContext.Users.OfType<Patient>().FirstOrDefaultAsync(p => p.Id == updatedpatient.Id);

        if (patient is not null)
        {
            patient.Email = updatedpatient.Email;
            patient.Phone = updatedpatient.Phone;
            patient.FullName = updatedpatient.FullName;
            patient.Address = updatedpatient.Address;
            patient.DateOfBirth = updatedpatient.DateOfBirth;
            patient.Gender = updatedpatient.Gender;
            patient.FacbookProfile = updatedpatient.FacbookProfile;
            patient.ProfilePhoto = updatedpatient.ProfilePhoto; 
        }
    }

    public async Task<List<Patient>> GetPatientsByName(string searchTerm)
    {
       var Patients =  await _appDbContext.Users.OfType<Patient>()
            .Where(p => p.FullName.Contains(searchTerm))
            .ToListAsync();

       return Patients;
    }

    public async Task<List<Patient>> GetAllPatients()
    {
        var Patients = await _appDbContext.Users.OfType<Patient>().ToListAsync();
        return Patients;
    }

    public async Task<PaginatedList<Patient>> GetAllPatients(int pageNumber, int pageSize)
    {
        var totalRecords = await _appDbContext.Users.OfType<Patient>().CountAsync();
        
        var patients = await _appDbContext.Users
            .OfType<Patient>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<Patient>(patients, totalRecords, pageNumber, pageSize);
    }

    public async Task Delete(string patientId)
    {
        var patient = await _appDbContext.Users.FirstOrDefaultAsync(p => p.Id == patientId);
        if (patient is not null)
        { 
            _appDbContext.Users.Remove(patient);
        }
    }

    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
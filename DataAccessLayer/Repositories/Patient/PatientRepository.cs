using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Entities;
public class PatientRepository:IPatientRepository
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
}
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
    public async Task<Patient?> GetById(int patientId)
    {
        var patient = await _appDbContext.Patients
            .FirstOrDefaultAsync(p => p.PatientId == patientId);

        return patient;
    }
    public async Task Add(Patient patient)
    {
        await _appDbContext.Patients.AddAsync(patient);
    }
    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }
    
}
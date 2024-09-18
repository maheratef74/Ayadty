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
    public async Task<ApplicationUser?> GetById(int patientId)
    {
        var patient = await _appDbContext.Users
            .FirstOrDefaultAsync(p => p.Id == patientId.ToString());

        return patient;
    }
}
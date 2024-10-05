using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Clinic;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Patient;
using Microsoft.EntityFrameworkCore;

public class ClinicRepository : IClinicRepository
{
    private readonly AppDbContext _appDbContext;

    public ClinicRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
       
    }
   
   
    public async Task<CliniC?> GetById(string clinicId)
    {
        var clinic = await _appDbContext.Clinic
            
            .FirstOrDefaultAsync(p => p.ClinicId == clinicId);

        return clinic;
    }


 

    public async Task Update(CliniC updatedClinic)
    {
        var clinic = await _appDbContext.Clinic
             .FirstOrDefaultAsync(a => a.ClinicId == updatedClinic.ClinicId);

        if (clinic is not null)
        {

            clinic.ClinicId = updatedClinic.ClinicId;

            clinic.Name = updatedClinic.Name;
            clinic.PhoneNumber = updatedClinic.PhoneNumber;
            clinic.Email = updatedClinic.Email;
            clinic.Location = updatedClinic.Location;
            clinic.DaysOfWork = updatedClinic.DaysOfWork;
            


          
        }
    }
    

    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }

   
}
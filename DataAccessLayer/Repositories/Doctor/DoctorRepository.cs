using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Doctor;
using DataAccessLayer.Entities;
public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _appDbContext;
    public DoctorRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Doctor?> GetById(string DoctorId)
    {
        var doctor = await _appDbContext.Users
            .OfType<Doctor>()
            .FirstOrDefaultAsync(d => d.Id == DoctorId);

        return doctor;
    }

    public async Task<Doctor?> GetDoctorByPhoneNUmber(string phoneNumber)
    {
        var doctor = await _appDbContext.Users
            .OfType<Doctor>()
            .FirstOrDefaultAsync(D => D.Phone == phoneNumber);

        return doctor;
    }

    public async Task Add(Doctor doctor)
    {
        await _appDbContext.Users.AddAsync(doctor);
    }

    public async Task SaveChange()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
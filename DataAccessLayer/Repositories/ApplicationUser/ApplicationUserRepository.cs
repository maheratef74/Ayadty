using DataAccessLayer.DbContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.ApplicationUser;

public class ApplicationUserRepository : IApplicationUserRepository
{
    private readonly AppDbContext _appDbContext;

    public ApplicationUserRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Entities.ApplicationUser?> GetUserByPhoneNUmber(string phoneNumber)
    {
        var user = await _appDbContext.Users
            .FirstOrDefaultAsync(D => D.Phone == phoneNumber);

        return user;
    }

    public async Task<Entities.ApplicationUser?> GetUserByPhoneAndExcludeCurrentPatient(string phoneNumber, string? patientId = null)
    {
        var query = _appDbContext.Users.AsQueryable();

        if (!string.IsNullOrEmpty(patientId))
        {
            query = query.Where(u => u.Id != patientId);
        }
        
        var user = await query.FirstOrDefaultAsync(u => u.Phone == phoneNumber);

        return user;
    }

}
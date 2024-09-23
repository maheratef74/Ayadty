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
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.DbContext;

public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-SG7M06R;database=Ayadty;Trusted_Connection=True;TrustServerCertificate=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}
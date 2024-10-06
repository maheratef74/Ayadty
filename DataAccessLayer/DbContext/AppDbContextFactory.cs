using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer("Server=GAFFER\\MSSQL ;database=Ayadty; Trusted_Connection=True; TrustServerCertificate=true");


        return new AppDbContext(optionsBuilder.Options);
    }
}
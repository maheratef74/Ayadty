
using DataAccessLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer("Server=db8857.databaseasp.net; Database=db8857; User Id=db8857; Password=iX-9%6BaCq7#; Encrypt=False; MultipleActiveResultSets=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}
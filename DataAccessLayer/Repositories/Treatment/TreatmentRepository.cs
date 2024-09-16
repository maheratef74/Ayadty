namespace DataAccessLayer.Repositories.Treatment;
using DataAccessLayer.Entities;
public class TreatmentRepository:ITreatmentRepository
{
    private readonly AppDbContext _appDbContext;

    public TreatmentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Treatment treatment)
    {
        await _appDbContext.Treatments.AddAsync(treatment);
    }

    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }
}
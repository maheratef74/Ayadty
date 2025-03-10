using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.WorkingDayes;

public class WorkingDayesRepository : IWorkinDayesRepository
{
    private readonly AppDbContext _appDbContext;

    public WorkingDayesRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task UpdateWoringDays(List<WorkDay> days)
    {
        // delete old days 
        var oldDays = await _appDbContext.WorkDays.ToListAsync();
       _appDbContext.WorkDays.RemoveRange(oldDays);
       
       // add newdays
        foreach (var day in days)
        {
            await _appDbContext.WorkDays.AddAsync(day);
        }
    }

    public async Task<List<WorkDay>> GetAllWorkingDays()
    {
        var workingDays = await _appDbContext.WorkDays.ToListAsync();

        return workingDays;
    }

    public async Task SaveChange()
    {
        await _appDbContext.SaveChangesAsync();

    }
    
}
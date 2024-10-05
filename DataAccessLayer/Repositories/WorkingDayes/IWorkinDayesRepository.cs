namespace DataAccessLayer.Repositories.WorkingDayes;
using DataAccessLayer.Entities;
public interface IWorkinDayesRepository
{
    Task UpdateWoringDays(List<WorkDay> days);
    Task<List<WorkDay>> GetAllWorkingDays();
    Task SaveChange();
}
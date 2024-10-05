using BusinessLogicLayer.DTOs.WorkingDayes;

namespace BusinessLogicLayer.Services.WorkingDays;
using DataAccessLayer.Entities;
public interface IWorkingDaysService
{
    Task AddWorkingDays(List<WorkingDayDto> workingDayDto);
    Task<List<WorkingDayDto>> GetAllWorkingDays();
}
using BusinessLogicLayer.DTOs.WorkingDayes;

namespace BusinessLogicLayer.Services.WorkingDays;
using DataAccessLayer.Entities;
public interface IWorkingDaysService
{
    Task AddWorkDay(List<WorkingDayDto> workingDayDto);
    Task<List<WorkingDayDto>> GetAllWorkingDays();
}
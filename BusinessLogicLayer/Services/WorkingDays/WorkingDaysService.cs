using BusinessLogicLayer.DTOs.WorkingDayes;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.WorkingDayes;
namespace BusinessLogicLayer.Services.WorkingDays;

public class WorkingDaysService : IWorkingDaysService
{
    private readonly IWorkinDayesRepository _workinDayesRepository;

    public WorkingDaysService(IWorkinDayesRepository workinDayesRepository)
    {
        _workinDayesRepository = workinDayesRepository;
    }


    public async Task AddWorkingDays(List<WorkingDayDto> workingDayDto)
    {
        var days = new List<WorkDay>();
        foreach (var dayDto in workingDayDto)
        {
            var WorkDay = dayDto.ToWorkDay();
            days.Add(WorkDay);
        }
        await _workinDayesRepository.UpdateWoringDays(days);
        await _workinDayesRepository.SaveChange();
    }

    public async Task<List<WorkingDayDto>> GetAllWorkingDays()
    {
        var wokingDays = await _workinDayesRepository.GetAllWorkingDays();

        var WorkingDaysDtos = new List<WorkingDayDto>();

        foreach (var day in wokingDays)
        {
            var dayDto = day.ToWorkDayDto();
            WorkingDaysDtos.Add(dayDto);
        }

        return WorkingDaysDtos;
    }
}
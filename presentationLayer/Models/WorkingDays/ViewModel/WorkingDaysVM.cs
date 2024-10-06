using BusinessLogicLayer.DTOs.WorkingDayes;

namespace presentationLayer.Models.WorkingDays.ViewModel;

public class WorkingDaysVM
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
}

public class workingDaysModel
{
    public List<WorkingDaysVM> WorkingDaysVms { get; set; }
}

public static class WorkingDayesExtensionmethold
{
    public static WorkingDaysVM ToWorkingDayVm(this WorkingDayDto workingDayDto)
    {
        return new WorkingDaysVM()
        {
            DayOfWeek = workingDayDto.DayOfWeek,
            StartTime = workingDayDto.StartTime,
            EndTime = workingDayDto.EndTime
        };
    }
    public static WorkingDayDto ToWorkingDayDto(this WorkingDaysVM workingDaysVm)
    {
        return new WorkingDayDto()
        {
            DayOfWeek = workingDaysVm.DayOfWeek,
            StartTime = workingDaysVm.StartTime,
            EndTime = workingDaysVm.EndTime
        };
    }
}
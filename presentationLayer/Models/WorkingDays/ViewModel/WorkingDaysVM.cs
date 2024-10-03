using BusinessLogicLayer.DTOs.WorkingDayes;

namespace presentationLayer.Models.WorkingDays.ViewModel;

public class WorkingDaysVM
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
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
}
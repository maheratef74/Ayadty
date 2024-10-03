using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.WorkingDayes;

public class WorkingDayDto
{
    public string Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public static class WoringDayedExtensionMethold
{
    public static WorkDay ToWorkDay(this WorkingDayDto workingDayDto)
    {
        return new WorkDay()
        {
            Id = workingDayDto.Id,
            DayOfWeek = workingDayDto.DayOfWeek,
            StartTime = workingDayDto.StartTime,
            EndTime = workingDayDto.EndTime
        };
    }
    
    public static WorkingDayDto ToWorkDayDto(this WorkDay workingDayDto)
    {
        return new WorkingDayDto()
        {
            Id = workingDayDto.Id,
            DayOfWeek = workingDayDto.DayOfWeek,
            StartTime = workingDayDto.StartTime,
            EndTime = workingDayDto.EndTime
        };
    }
}
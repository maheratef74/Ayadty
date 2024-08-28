namespace Ayadty.Models;

public class WorkDay
{
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int DayTimeId { get; set; } // Foreign Key property
    public DayTime DayTime { get; set; }
}
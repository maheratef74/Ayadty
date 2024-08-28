namespace Ayadty.Models;

public class DayTime
{
    public int DayTimeId { get; set; }
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
}
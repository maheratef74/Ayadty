using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class WorkDay
{
    [Key]
    public string Id { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
}
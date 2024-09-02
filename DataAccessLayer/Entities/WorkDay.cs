using System.ComponentModel.DataAnnotations;

namespace Ayadty.Models;

public class WorkDay
{
    [Key]
    public int Id { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
}
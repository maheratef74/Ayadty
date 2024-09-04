using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ayadty.Models;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string PatientName { get; set; }
    public string PatientContact { get; set; }
    public Enums.AppointmentStatus Status { get; set; } // Enum for status
    
    [ForeignKey("Patient")]
    public int PatientId { get; set; } // Foreign Key
    public Patient Patient { get; set; } // Navigation property
    
    public int Order { get; set; }
}
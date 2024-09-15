using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace DataAccessLayer.Entities;
public class Appointment
{
    [Key]
    public int AppointmentId { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public Enums.AppointmentStatus Status { get; set; } // Enum for status
    public Enums.PatientProgress PatientProgress { get; set; }
    [ForeignKey("Patient")]
    public int PatientId { get; set; } // Foreign Key
    public Patient Patient { get; set; } // Navigation proper
    public int Order { get; set; } 
    public string? Note { get; set; }
}
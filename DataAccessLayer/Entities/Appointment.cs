using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ayadty.Models;

public class Appointment
{
    public int AppointmentId { get; set; } // Primary Key
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public string PatientName { get; set; }
    public string PatientContact { get; set; }
    public Enums.AppointmentStatus Status { get; set; } // Enum for status
    public int PatientId { get; set; } // Foreign Key
    public Patient Patient { get; set; } // Navigation property
}
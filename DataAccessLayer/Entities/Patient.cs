using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayadty.Models;

public class Patient
{
    [Key]
    public int PatientId { get; set; }  // Primary Key
    public string Name { get; set; }
    
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    public string PhoneNumber { get; set; } // >>> it will be the real pk
    public string? Email { get; set; }
    public string Address { get; set; }
    
    public List<Appointment> Appointments { get; set; } // One-to-Many
    public List<MedicalRecord> MedicalRecords { get; set; } // One-to-Many
}
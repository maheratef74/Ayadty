namespace Ayadty.Models;

public class Patient
{
    public int PatientId { get; set; } // Primary Key
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    
    public List<Appointment> Appointments { get; set; } // One-to-Many
    public List<MedicalRecord> MedicalRecords { get; set; } // One-to-Many
    public List<Doctor> Doctors { get; set; } // Many-to-Many
}
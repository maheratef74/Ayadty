namespace Ayadty.Models;

public class Doctor
{
    public int DoctorId { get; set; } // Primary Key
    public string Name { get; set; }
    public  Enums.Specialization  Specialization { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int YearsOfExperience { get; set; }
    public decimal? Price { get; set; }
    
    public int ClinicId { get; set; } // Foreign Key for one-to-one relationship
    public Clinic Clinic { get; set; } // Navigation property
    
    public List<Appointment> Appointments { get; set; } // One-to-Many
    public List<MedicalRecord> MedicalRecords { get; set; } // One-to-Many
    public List<Patient> Patients { get; set; } // Many-to-Many
    public List<Prescription>Prescriptions { get; set; }
}

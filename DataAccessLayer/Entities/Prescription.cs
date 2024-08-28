namespace Ayadty.Models;

public class Prescription
{
    public int PrescriptionId { get; set; } // Primary Key
        
    public int? MedicalRecordId { get; set; } // Foreign Key, nullable if not all prescriptions are linked
    public MedicalRecord MedicalRecord { get; set; } // Navigation property
        
    public int DoctorId { get; set; } // Foreign Key from Doctor
    public Doctor Doctor { get; set; } // Navigation property
        
    public DateTime Date { get; set; }
    public List<string> Treatments { get; set; } = new List<string>();
    public string? Notes { get; set; }
}
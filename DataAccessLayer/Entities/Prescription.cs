namespace Ayadty.Models;

public class Prescription
{
    public int PrescriptionId { get; set; } // Primary Key
    
    public int? MedicalRecordId { get; set; } // Foreign Key, nullable if not all prescriptions are linked
    public MedicalRecord MedicalRecord { get; set; } // Navigation property
    
    public DateTime Date { get; set; }
    public List<Treatment> Treatments { get; set; } = new List<Treatment>();
    public string? Notes { get; set; }
}
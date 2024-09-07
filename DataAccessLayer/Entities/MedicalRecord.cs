namespace Ayadty.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
public class MedicalRecord
{
    [Key]
    public int MedicalRecordId { get; set; } // Primary Key
    
    [ForeignKey("Patient")]
    public int PatientId { get; set; } // Foreign Key
    public Patient Patient { get; set; } // Navigation property
    
    [ForeignKey("Prescription")]
    public int? PrescriptionId { get; set; } // Foreign Key, nullable if not all records have prescriptions
    public Prescription Prescription { get; set; } // Navigation property
        

        
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}


namespace Ayadty.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
public class MedicalRecord
{
    public int MedicalRecordId { get; set; } // Primary Key
    public int PatientId { get; set; } // Foreign Key
    public Patient Patient { get; set; } // Navigation property
        
    public int DoctorId { get; set; } // Foreign Key
    public Doctor Doctor { get; set; } // Navigation property
        
    public int ClinicId { get; set; } // Foreign Key
    public Clinic Clinic { get; set; } // Navigation property
        
    public int? PrescriptionId { get; set; } // Foreign Key, nullable if not all records have prescriptions
    public Prescription Prescription { get; set; } // Navigation property
        
    public string Diagnosis { get; set; }
        
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
}


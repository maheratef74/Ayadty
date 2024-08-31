namespace Ayadty.Models;

public class Clinic
{
    public int ClinicId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public List<WorkDay> DaysOfWork { get; set; } 
    
    public Doctor Doctor { get; set; } // One-to-One relationship
    public List<MedicalRecord> MedicalRecords { get; set; } // One-to-Many
}// it will be one clinic but set it her to add update to days of work 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Clinic
{
    [Key]
    public int ClinicId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Location { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; } 
    public List<WorkDay> DaysOfWork { get; set; } 
    
    public List<Prescription> Prescriptions { get; set; } // One-to-Many
}
// it will be one clinic but set it her to add update to days of work 
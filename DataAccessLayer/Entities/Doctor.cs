using System.ComponentModel.DataAnnotations;

namespace Ayadty.Models;

public class Doctor
{
    [Key]
    public int DoctorId { get; set; } // Primary Key
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool IsAvalibleToAppoinment { get; set; }
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; } 
    public int? YearsOfExperience { get; set; }
    public decimal? Price { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities;

public class Patient : ApplicationUser
{
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    public string? FacbookProfile { get; set; }
    public string Address { get; set; }
    
    public List<Appointment> Appointments { get; set; } // One-to-Many
    public List<Prescription> Prescriptions { get; set; } // One-to-Many
}
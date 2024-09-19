using BusinessLogicLayer.DTOs.Appointment;

namespace BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;

public class PatientDetailsDto
{
    public string PatientId { get; set; }  // Primary Key
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    public string PhoneNumber { get; set; } // >>> it will be the real pk
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; } 
    public string Address { get; set; }
    
    public string? FacbookProfile { get; set; }
}
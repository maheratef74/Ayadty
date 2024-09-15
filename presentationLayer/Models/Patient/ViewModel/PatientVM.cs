using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;

namespace presentationLayer.Models.Patient.ViewModel;

public partial class PatientVM
{
    public int PatientId { get; set; }  // Primary Key
    public string Name { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    public string PhoneNumber { get; set; } // >>> it will be the real pk
    public string? Email { get; set; }
    public string? ProfilePhoto { get; set; } 
    public string Address { get; set; }
    
    public string? FacbookProfile { get; set; }
}
public static  class PatientVmExtensions
{
    public static PatientVM ToPatientVM(this PatientDetailsDto dto)
    {
        return new PatientVM
        {
            PatientId = dto.PatientId,
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            ProfilePhoto = dto.ProfilePhoto,
            Address = dto.Address,
            FacbookProfile = dto.FacbookProfile
        };
    }
}
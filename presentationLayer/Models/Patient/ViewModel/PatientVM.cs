using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;
using presentationLayer.Models.Auth.ActionRequest;
using DataAccessLayer.Entities;
namespace presentationLayer.Models.Patient.ViewModel;

public  class PatientVM
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
    public static DataAccessLayer.Entities.Patient ToPatient(this RegisterAR newPatient)
    {
        var patient = new DataAccessLayer.Entities.Patient()
        {
            FullName = newPatient.Name,
            Phone = newPatient.PhoneNumber,
            Address = newPatient.Address,
            Gender = newPatient.Gender,
            //  PasswordHash = newPatient.Password,
            DateOfBirth = newPatient.DateOfBirth,
            UserName = Guid.NewGuid().ToString() , // because it take alotof time to handel it but it's not handel 
            ProfilePhoto = newPatient.Gender == 0 ? "man.jpg" : "Female.jpg"
        };
        
        return patient;
    }
  
}
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;

namespace presentationLayer.Models.Patient.ViewModel;

public class UpdatePatientAR
{
    public string PatientId { get; set; }
    
    [Required(ErrorMessage = "DateOfBirthRequired")]
    public DateTime DateOfBirth { get; set; }
    public Enums.Gender Gender { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "AddressRequired")]
    public string Address { get; set; }
    
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [DataType(DataType.Password)]
    [Compare("Password" , ErrorMessage = "The two passwords do not match.")]
    public string? ConfirmPassword { get; set; }
    public string? FacebookProfile { get; set; }
    
    [Required(ErrorMessage = "NameRequired")]
    public string FullName { get; set; }
    
    [Required(ErrorMessage = "PhoneNumberRequired")]
    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")] 
    [UniquePhoneNumber]
    public string Phone { get; set; }
    public string? ProfilePhoto { get; set; }
    public IFormFile? FormFilePhoto { get; set; }
}
public static class UpdatePatientExtenionMethod
{
    public static UpdatePatientDto ToUpdatePatientDto(this UpdatePatientAR ar)
    {
        return new UpdatePatientDto
        {
            PatientId = ar.PatientId,
            DateOfBirth = ar.DateOfBirth,
            FullName = ar.FullName,
            Phone = ar.Phone,
            FacebookProfile = ar.FacebookProfile,
            Gender = ar.Gender,
            Email = ar.Email,
            Address = ar.Address,
        };

    }
    public static UpdatePatientAR ToUpdatePatientVM(this PatientDetailsDto dto)
    {
        return new UpdatePatientAR
        {
            PatientId= dto.PatientId,
            FullName = dto.Name,
            Phone = dto.PhoneNumber,
            FacebookProfile = dto.FacbookProfile,
            Gender = dto.Gender,
            Email = dto.Email,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            ProfilePhoto = dto.ProfilePhoto
        };
    }
}

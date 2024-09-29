using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace presentationLayer.Models.Doctor.ActionRequest;

public class AddDoctorAR
{
    [Required(ErrorMessage = "NameRequired")]
    public string Name { get; set; }

    [Required(ErrorMessage = "PasswordIsRequired")]
    [DataType(DataType.Password)]
    [MinLength(6 , ErrorMessage = "PasswardAtLeast6Digit")]
    public string Password { get; set; }
    
    [DataType(DataType.Password)]
    [Compare("Password" , ErrorMessage = "The two passwords do not match.")]
    [Required(ErrorMessage = "PasswordIsRequired")]
    public string ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "GenderRequired")]
    public Enums.Gender Gender { get; set; }
    
    [Required(ErrorMessage = "DateOfBirthRequired")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")] 
  //  [UniquePhoneNumber]
    [Remote(action: "CheckPhoneForRegister", controller: "auth", AdditionalFields = nameof(PhoneNumber) ,ErrorMessage = "Use Another Phone Number" )]
    [Required(ErrorMessage = "PhoneNumberRequired")]
    public string PhoneNumber { get; set; }
    public bool RememberMe { get; set; }

}

public static class DctorExtensionMethold
{
    public static DataAccessLayer.Entities.Doctor ToDoctor(this AddDoctorAR doctorAr)
    {
        return new DataAccessLayer.Entities.Doctor()
        {
            FullName = doctorAr.Name,
            Phone = doctorAr.PhoneNumber,
            Gender = doctorAr.Gender,
            DateOfBirth = doctorAr.DateOfBirth,
            UserName = Guid.NewGuid().ToString(),
            ProfilePhoto = doctorAr.Gender == 0 ? "man.jpg" : "Female.jpg"
        };
    }
}
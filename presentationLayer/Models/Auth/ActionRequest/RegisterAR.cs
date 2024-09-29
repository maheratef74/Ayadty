using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;


namespace presentationLayer.Models.Auth.ActionRequest;

public class RegisterAR
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
    
    [Required(ErrorMessage = "AddressRequired")]
    public string  Address { get; set; }

    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")] 
    [UniquePhoneNumber]
   // [Remote(action: "CheckPhone", controller: "auth", ErrorMessage = "PhoneNumberInvalid")]
    [Required(ErrorMessage = "PhoneNumberRequired")]
    public string PhoneNumber { get; set; }
    public bool RememberMe { get; set; }

}
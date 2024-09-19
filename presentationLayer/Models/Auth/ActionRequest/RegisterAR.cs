using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using presentationLayer.Validation;

namespace presentationLayer.Models.Auth.ActionRequest;

public class RegisterAR
{
    [Required(ErrorMessage = "NameRequired")]
    public string Name { get; set; }

    [Required(ErrorMessage = "PasswordRequired")]
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    
    [Required(ErrorMessage = "GenderRequired")]
    public Enums.Gender Gender { get; set; }
    
    [Required(ErrorMessage = "DateOfBirthRequired")]
    public DateTime DateOfBirth { get; set; }
    
    [Required(ErrorMessage = "AddressRequired")]
    public string  Address { get; set; }

    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")]
    // [UniquePhoneNumber(ErrorMessage = "PhoneNumberInvalid")]
    [Remote(action: "CheckPhone", controller: "authController", ErrorMessage = "PhoneNumberInvalid")]
    public string PhoneNumber { get; set; }
    public bool RememberMe { get; set; }

}
﻿using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Ptient;
using DataAccessLayer.Entities;
using presentationLayer.Validation;

namespace presentationLayer.Models.Patient.ViewModel;

public class UpdatePatientVM
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
    [UniquePhoneNumber]
    [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "PhoneNumberInvalid")] 
    public string Phone { get; set; }
    
    public string? ProfilePhoto { get; set; }
}
public static class UpdatePatientExtenionMethod
{
    public static UpdatePatientDto ToUpdatePatientDto(this UpdatePatientVM vm)
    {
        return new UpdatePatientDto
        {
            PatientId = vm.PatientId,
            DateOfBirth = vm.DateOfBirth,
            FullName = vm.FullName,
            Phone = vm.Phone,
            FacebookProfile = vm.FacebookProfile,
            Gender = vm.Gender,
            Email = vm.Email,
            Address = vm.Address,
            ProfilePhoto = vm.ProfilePhoto,
        };

    }
    public static UpdatePatientVM ToUpdatePatientVM(this PatientDetailsDto dto)
    {
        return new UpdatePatientVM
        {
            PatientId= dto.PatientId,
            FullName = dto.Name,
            Phone = dto.PhoneNumber,
            FacebookProfile = dto.FacbookProfile,
            Gender = dto.Gender,
            Email = dto.Email,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            ProfilePhoto = dto.ProfilePhoto,
        };
    }
}

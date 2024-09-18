
using BusinessLogicLayer.DTOs.Patient;
using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using presentationLayer.Controllers;

namespace presentationLayer.Models.Patient.ActionRequst;

public class PatientAR
{
    [Required(ErrorMessage = "NameRequired")]
    public string Name { get; set; }

    [Required(ErrorMessage = "PasswardRequired")]
    public string Password { get; set; }

    [Required(ErrorMessage = "GenderRequired")]
    public Enums.Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }

    public string PhoneNumber { get; set; }

    public string ConfitmPassword { get; set; }

    public AddPatientDto toDto()
    {
        return new AddPatientDto
        {
            Name = Name,
            Password = Password,
            Gender = Gender,
            PhoneNumber = PhoneNumber,
            
        };
    }
}
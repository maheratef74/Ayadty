using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Appointment;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using presentationLayer.Controllers;

public class CreatAppointmentAR
{
    [Required(ErrorMessage = "NameRequired")]
    public string PatientName { get; set; }
    public string PatieentId { get; set; }
    public string PatientContact { get; set; }
    public string? Note { get; set; }
   
    public CreatAppointmentDto ToDto()
    {
        return new CreatAppointmentDto
        {
            PatientId = PatieentId,
            PatientName = PatientName,
            PatientContact = PatientContact,
            Note = Note 
        };
    }
}
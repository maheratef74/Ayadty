using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Appointment;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using presentationLayer.Controllers;

public class CreatAppointmentAR
{
    public string PatientName { get; set; }
    public string Phone { get; set; }
    public string? Note { get; set; }

    public CreatAppointmentDto ToDto()
    {
        return new CreatAppointmentDto
        {
            PatientName = PatientName,
            Note = Note 
        };
    }
}
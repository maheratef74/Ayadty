using System.Data;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;
public class UpdateAppointmentDto
{
    public string AppointmentId { get; set; }
    public string PatientId{ get; set; }
    public string? profilePhoto { get; set; }
    public string PatientContact { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public string PatientAdress { get; set; }
    public AppointmentStatus Status { get; set; }
    public PatientProgress PatientProgress { get; set; }
    public int Order { get; set; } 
    public string? Note { get; set; }  
}

public static class UpdateAppointmentExtensionMethold
{
    public static Appointment? ToUpdatedAppointment(this UpdateAppointmentDto? updateAppointmentDto)
    {
        if (updateAppointmentDto == null )
        {
            return null;
        }
       
        var appointment = new Appointment()
        {
            AppointmentId = updateAppointmentDto.AppointmentId,
            PatientContact = updateAppointmentDto.PatientContact,
            PatientId = updateAppointmentDto.PatientId,
            Date = updateAppointmentDto.Date,
            PatientName = updateAppointmentDto.PatientName, 
            Status = (Enums.AppointmentStatus)updateAppointmentDto.Status,
            PatientProgress = (Enums.PatientProgress)updateAppointmentDto.PatientProgress, 
            Order = updateAppointmentDto.Order,
            Note = updateAppointmentDto.Note
        };
        return appointment;
    }
}
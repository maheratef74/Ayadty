using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;

namespace presentationLayer.Models.Appointment.ViewModel;

public class UpdateAppointmentVM
{
    public string AppointmentId { get; set; }
    public string PatientId{ get; set; }
    public string? profilePhoto { get; set; }
    public string PatientContact { get; set; }
    
    [Required(ErrorMessage = "DataIsRequried")]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "NameRequired")]
    public string PatientName { get; set; }
    
    [Required(ErrorMessage = "AddressRequired")]
    public string PatientAdress { get; set; }
    public Enums.AppointmentStatus Status { get; set; }
    public Enums.PatientProgress PatientProgress { get; set; }
    [Required(ErrorMessage = "OrderIsRequired")]
    public int Order { get; set; } 
    
    public string? Note { get; set; }
}

public static class AppointmentExtensionMethold
{
    public static UpdateAppointmentVM ToAppointmentVm(this AppointmentDetailsDto appointmentDetailsDto)
    {
        return new UpdateAppointmentVM()
        {
            PatientContact = appointmentDetailsDto.PatientContact,
            PatientProgress = (Enums.PatientProgress)appointmentDetailsDto.PatientProgress,
            Order = appointmentDetailsDto.Order,
            Note = appointmentDetailsDto.Note,
            profilePhoto = appointmentDetailsDto.profilePhoto,
            PatientName = appointmentDetailsDto.PatientName,
            Status = appointmentDetailsDto.Status,
            PatientAdress = appointmentDetailsDto.PatientAdress,
            PatientId = appointmentDetailsDto.PatientId,
            Date = appointmentDetailsDto.Date,
            AppointmentId = appointmentDetailsDto.AppointmentId
        };
    }
    
    public static UpdateAppointmentDto ToAppointmentDto(this UpdateAppointmentVM updateAppointmentVm)
    {
        return new UpdateAppointmentDto()
        {
            PatientContact = updateAppointmentVm.PatientContact,
            PatientProgress = (PatientProgress)updateAppointmentVm.PatientProgress,
            Order = updateAppointmentVm.Order,
            Note = updateAppointmentVm.Note,
            profilePhoto = updateAppointmentVm.profilePhoto,
            PatientName = updateAppointmentVm.PatientName,
            Status = (AppointmentStatus)updateAppointmentVm.Status,
            PatientAdress = updateAppointmentVm.PatientAdress,
            PatientId = updateAppointmentVm.PatientId,
            Date = updateAppointmentVm.Date,
            AppointmentId = updateAppointmentVm.AppointmentId
        };
    }
}
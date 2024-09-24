namespace BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;
public class AppointmentDetailsDto
{
    public string AppointmentId { get; set; }
    public string PatientId{ get; set; }
    public string? profilePhoto { get; set; }
    public string PatientContact { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public string PatientAdress { get; set; }
    public Enums.AppointmentStatus Status { get; set; }
    public PatientProgress PatientProgress { get; set; }
    public int Order { get; set; } 
    public string? Note { get; set; }
}

public static class AppointmentDetailsExtensionMethold
{
    public static AppointmentDetailsDto? ToAppointmetDto(this Appointment? app)
    {
        if (app == null )
        {
            return null;
        }
        var appointmentDetails = new AppointmentDetailsDto
        {
            AppointmentId = app.AppointmentId,
            profilePhoto = app.Patient.ProfilePhoto,
            PatientContact = app.Patient.Phone,
            PatientId = app.PatientId,
            PatientAdress = app.Patient.Address,
            Date = app.Date,
            PatientName = app.PatientName, 
            Status = app.Status,
            PatientProgress = (PatientProgress)app.PatientProgress, 
            Order = app.Order,
            Note = app.Note
        };
        return appointmentDetails;
    }
}
namespace BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;
public class AppointmentDetailsDto
{
    public int AppointmentId { get; set; }
    public int PatientId{ get; set; }
    public string? profilePhoto { get; set; }
    public string PatientContact { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    
    public string PatientAdress { get; set; }
    public Enums.AppointmentStatus Status { get; set; }
    public Services.Appointment.PatientProgress PatientProgress { get; set; }
    public int Order { get; set; } 
    public string? Note { get; set; }
}
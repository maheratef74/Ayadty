namespace BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Entities;
public enum AppointmentStatus
{
    Scheduled,
    Canceled ,
    Completed
}
public enum PatientProgress
{
    InHome,
    InMyWayToClinic,
    InClinic
}
public class CreatAppointmentDto
{
    public int AppointmentId { get; set; }
    public DateTime Date { get; set; }
    public string PatientName { get; set; }
    public int PatientId{ get; set; }
    public Enums.AppointmentStatus Status { get; set; }
    public Services.Appointment.PatientProgress PatientProgress { get; set; }
    public int Order { get; set; } 
    public string? Note { get; set; }
}

public static class CreatAppointmentDtoExtensions
{
    public static Appointment ToAppointment(this CreatAppointmentDto dto )
    {
        return new Appointment
        {
            PatientId = 2,
            Date = dto.Date,
            PatientName = dto.PatientName,
            Status = dto.Status,
            PatientProgress = (Enums.PatientProgress)dto.PatientProgress,
            Order = dto.Order,
            Note = dto.Note
        };
    }
}
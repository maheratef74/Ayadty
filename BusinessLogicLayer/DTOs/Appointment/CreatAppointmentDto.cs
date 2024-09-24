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
    public string PatientContact { get; set; }
    public string PatientId{ get; set; }
    public Enums.AppointmentStatus Status { get; set; }
    public Enums.PatientProgress PatientProgress { get; set; }
    public int Order { get; set; } 
    public string? Note { get; set; }
}

public static class CreatAppointmentDtoExtensions
{
    public static Appointment ToAppointment(this CreatAppointmentDto dto )
    {
        return new Appointment
        {
            AppointmentId = Guid.NewGuid().ToString(),
            PatientId = dto.PatientId,
            Date = DateTime.Now,
            PatientName = dto.PatientName,
            PatientContact = dto.PatientContact,
            Status = (Enums.AppointmentStatus)AppointmentStatus.Scheduled,
            PatientProgress = (Enums.PatientProgress)PatientProgress.InHome,
            Note = dto.Note
        };
    }
}
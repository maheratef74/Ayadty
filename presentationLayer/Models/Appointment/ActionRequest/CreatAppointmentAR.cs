using BusinessLogicLayer.DTOs.Appointment;

namespace presentationLayer.Models.Appointment.ActionRequest;

public class CreatAppointmentAR
{
    private int PatientId { get; set; }
    public string PatientName { get; set; }
    public string Phone { get; set; }
    public string Note { get; set; }

    public CreatAppointmentDto ToDto()
    {
        return new CreatAppointmentDto
        {
            PatientId = PatientId,
            PatientName = PatientName,
            Note = Note
        };
    }
}
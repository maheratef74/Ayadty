using BusinessLogicLayer.DTOs.Appointment;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Models.DashBoard.ViewModel;

public class NurseAppointmentVM
{
    
    public string SelectedPatientId { get; set; }
    public string PatientName { get; set; }
    public string patientPhone { get; set; }
    public List<PatientVM> Patients { get; set; }
    public DateTime Date { get; set; }
    public string? Note { get; set; }
    public string SearchTerm { get; set; } 
}

public static class ToDtoExtensionMethold
{
    public static CreatAppointmentDto ToAppointmentDto(this NurseAppointmentVM appointmentVm)
    {
        return new CreatAppointmentDto()
        {
            Date = appointmentVm.Date,
            PatientContact = appointmentVm.patientPhone,
            Note = appointmentVm.Note,
            PatientName = appointmentVm.PatientName,
            PatientId = appointmentVm.SelectedPatientId
        };
    }
}
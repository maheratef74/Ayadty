using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Models.Appointment.CompositeViewModel;

public class AppointmentPageVM_AR
{
    public PatientVM PatientVM { get; set; }  // For showing default values
    public CreatAppointmentAR CreatAppointmentAR { get; set; }  // For form submission
}
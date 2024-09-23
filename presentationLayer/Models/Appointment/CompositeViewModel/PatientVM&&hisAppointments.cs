using BusinessLogicLayer.DTOs.Appointment;
using presentationLayer.Models.Appointment.ViewModel;
using presentationLayer.Models.Patient.ViewModel;

namespace presentationLayer.Models.Appointment.CompositeViewModel;

public class PatientVM__hisAppointments
{
    public PatientVM PatientVm { get; set; }

    public List<AppointmentDetailsDto>  AppointmentsDetailsDto { get; set; }
}


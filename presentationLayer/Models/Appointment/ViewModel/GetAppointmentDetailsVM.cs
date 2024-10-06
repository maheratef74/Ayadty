using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.DTOs.Prescription;

namespace presentationLayer.Models.Appointment.ViewModel;
using DataAccessLayer.Entities;

public class GetAppointmentDetailsVM
{
   public AppointmentDetailsDto appointment { get; set; }
   public List<PrescriptionDetailsDto> PrescriptionsDetail { get; set; }
}
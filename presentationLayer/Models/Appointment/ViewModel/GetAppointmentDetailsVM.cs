using BusinessLogicLayer.DTOs.Appointment;

namespace presentationLayer.Models.Appointment.ViewModel;
using DataAccessLayer.Entities;

public class GetAppointmentDetailsVM
{
   public AppointmentDetailsDto appointment { get; set; }
}
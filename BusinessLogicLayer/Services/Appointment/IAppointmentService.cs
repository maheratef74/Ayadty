using System.Linq.Expressions;
using BusinessLogicLayer.DTOs.Appointment;
namespace BusinessLogicLayer.Services.Appointment;

public interface IAppointmentService
{
    Task CreatAppointment(CreatAppointmentDto creatAppointmentDto);
    Task<List<AppointmentDetailsDto>> GetAllForDay(DateTime? data);
    Task<AppointmentDetailsDto?> GetAppointmentByID(string appointmentId);
    Task<List<AppointmentDetailsDto>> GetAllAppointmentByPatientId(string PatientId);

    Task UpdateAppointment(UpdateAppointmentDto UpdaedappointmentDetailsDto);

    Task CanceleAppointment(string appointmentId);
    Task DeleteAppointment(string appointmentId);
}
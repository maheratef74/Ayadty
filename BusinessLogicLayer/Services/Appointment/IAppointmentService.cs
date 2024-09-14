using System.Linq.Expressions;
using BusinessLogicLayer.DTOs.Appointment;
namespace BusinessLogicLayer.Services.Appointment;

public interface IAppointmentService
{
    Task CreatAppointment(CreatAppointmentDto creatAppointmentDto);
    Task<List<AppointmentDetailsDto>> GetAllForDay(DateTime? data);
    Task<AppointmentDetailsDto> GetAppointmentByID(int appointmentId);
}
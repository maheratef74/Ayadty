using BusinessLogicLayer.DTOs.Appointment;
using BusinessLogicLayer.Services.Notification;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Localization;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.Services.Appointment;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentsRepository;
    private readonly INotificationService _notificationService;
    public AppointmentService(IAppointmentRepository appointmentsRepository, INotificationService notificationService)
    {
        _appointmentsRepository = appointmentsRepository;
        _notificationService = notificationService;
    }

    public async Task CreatAppointment(CreatAppointmentDto creatAppointmentDto)
    {
        var appointment = creatAppointmentDto.ToAppointment();
        appointment.Order = await _appointmentsRepository.GetMaxOrderOfDay() + 1;
        await _appointmentsRepository.Add(appointment);
        await _appointmentsRepository.SaveChanges();
        
        // Create a notification for the doctor
        string message = $"حجز جديد تم من خلال {appointment.PatientName}.";
      
        await _notificationService.CreateNotification(message);
    }

    public async Task<List<AppointmentDetailsDto>> GetAllForDay(DateTime? data)
    {
        var dateToCheck = data ?? DateTime.Today; // Default to today's date if null
                                                         // and it handel agin in repository
        var appointments = await _appointmentsRepository.GetAllForDay(dateToCheck);

        var appointmentDetailsList = new List<AppointmentDetailsDto>();

        foreach (var app in appointments)
        {
            appointmentDetailsList.Add(app.ToAppointmetDto());
        }
        return appointmentDetailsList;
    }

    public async Task<AppointmentDetailsDto?> GetAppointmentByID(string appointmentId)
    {
        var appointment = await _appointmentsRepository.GetAppointmentByIdIncludingPatient(appointmentId);
        
        return appointment?.ToAppointmetDto();
    }

    public async Task<List<AppointmentDetailsDto>> GetAllAppointmentByPatientId(string PatientId)
    {
        var appointments = await _appointmentsRepository.GetAllByPatientId(PatientId);

        var appointmentDetailsList = new List<AppointmentDetailsDto>();

        foreach (var app in appointments)
        {
            appointmentDetailsList.Add(app.ToAppointmetDto());
        }
        return appointmentDetailsList;
    }
    public async Task UpdateAppointment(UpdateAppointmentDto UpdaedappointmentDetailsDto)
    {
        var appointment = UpdaedappointmentDetailsDto.ToUpdatedAppointment();
        
        await _appointmentsRepository.Update(appointment); 
        await _appointmentsRepository.SaveChanges();
        
        // Create a notification for the doctor
        string message = $"تم تعديل حجز {appointment.PatientName}.";
       
        await _notificationService.CreateNotification(message);
    }
    public async Task CanceleAppointment(string appointmentId)
    {
        var appointment = await _appointmentsRepository.GetById(appointmentId);
        await _appointmentsRepository.Cancel(appointmentId);
        await _appointmentsRepository.SaveChanges();
        
        // Create a notification for the doctor
        string message = $"تم الغاء حجز {appointment.PatientName}.";
       
        await _notificationService.CreateNotification(message);
    }
    public async Task DeleteAppointment(string appointmentId)
    {
        var appointment = await _appointmentsRepository.GetById(appointmentId);
        await _appointmentsRepository.Delete(appointmentId);
        await _appointmentsRepository.SaveChanges();
        
        // Create a notification for the doctor
        string message = $"تم حذف حجز {appointment.PatientName}.";
       
        await _notificationService.CreateNotification(message);
    }
}
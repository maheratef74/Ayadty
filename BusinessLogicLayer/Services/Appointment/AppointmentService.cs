using BusinessLogicLayer.DTOs.Appointment;
using DataAccessLayer.Repositories;
using DataAccessLayer.Entities;
namespace BusinessLogicLayer.Services.Appointment;
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

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentsRepository;

    public AppointmentService(IAppointmentRepository appointmentsRepository)
    {
        _appointmentsRepository = appointmentsRepository;
    }

    public async Task CreatAppointment(CreatAppointmentDto creatAppointmentDto)
    {
        // set defulte values
        creatAppointmentDto.Order = await _appointmentsRepository.GetMaxOrderOfDay() + 1;
        creatAppointmentDto.PatientProgress = PatientProgress.InHome;
        creatAppointmentDto.Date = DateTime.Now;
        creatAppointmentDto.Status = Enums.AppointmentStatus.Scheduled;

        var appointment = creatAppointmentDto.ToAppointment();
        await _appointmentsRepository.Add(appointment);
        await _appointmentsRepository.SaveChanges();
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

    public async Task<AppointmentDetailsDto> GetAppointmentByID(int appointmentId)
    {
        var appointment = await _appointmentsRepository.GetAppointmentByIdIncludingPatient(appointmentId);
        
        return appointment.ToAppointmetDto();
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
}
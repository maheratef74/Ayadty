using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class AppointmentRepository:IAppointmentRepository
{
    private readonly AppDbContext _appDbContext;
    private IAppointmentRepository _appointmentRepositoryImplementation;

    public AppointmentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<List<Appointment>> GetAll()
    {
        return await _appDbContext.Appointments
            .OrderByDescending(a => a.Date)
            .ToListAsync(); // Convert the query result to a list asynchronously
    }

    public async Task<List<Appointment>> GetAllForToday()
    {
        var today = DateTime.Today;
        var todayAppointments = _appDbContext.Appointments
            .Where(a => a.Date == today)
            .OrderByDescending(a => a.Order).ToListAsync();

        return await todayAppointments;
    }

    public async Task<List<Appointment>> GetAllByPatientId(int patientId)
    {
        return await _appDbContext.Appointments 
            .Where(a => a.PatientId == patientId )
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task<Appointment?> GetById(int id)
    {
        return await _appDbContext.Appointments
            .FirstOrDefaultAsync(Appointment => Appointment.AppointmentId == id);
    }

    public async Task<int> GetMaxOrder()
    {
        var today = DateTime.Today;
        var maxOrder = _appDbContext.Appointments
            .Where(Appointment => Appointment.Date == today)
            .MaxAsync(Appointment => Appointment.Order);
        
        return await maxOrder;
    }

    public async Task<bool> IsAvaliable(int doctorId)
    {
        var doctor = await _appDbContext.Doctor
            .FirstOrDefaultAsync(d => d.DoctorId == doctorId);
        
        return doctor != null && doctor.IsAvalibleToAppoinment;
    }

    public async Task Add(Appointment Appointment)
    {
        await _appDbContext.Appointments.AddAsync(Appointment);
    }

    public async Task Update(Appointment updatedAppointment)
    {
        var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == updatedAppointment.AppointmentId);
        
        if (appointment != null)
        {
           /* if (role == "doctor")   untile make auth
            {
                appointment.Order = updatedAppointment.Order;
                appointment.PatientName = updatedAppointment.PatientName;
                appointment.Status = updatedAppointment.Status;
                appointment.PatientProgress = updatedAppointment.PatientProgress;
            }
            else if (role == "patient")
            {
                appointment.Status = updatedAppointment.Status;  // from pending to cancel only
                appointment.PatientProgress = updatedAppointment.PatientProgress;
            }
            */
        }
    }

    public async Task Delete(int id)
    {
        var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == id);
        if (appointment is not null)
        { 
            _appDbContext.Appointments.Remove(appointment);
        }
    }

    public async Task Cancel(int id)
    {
        var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == id);
        if (appointment is not null)
        {
            appointment.Status = Enums.AppointmentStatus.Canceled;
        }
    }

    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Appointment> GetAppointmentByIdIncludingPatient(int id)
    {
        throw new NotImplementedException();
    }
}
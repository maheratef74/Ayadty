using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AppointmentRepository:IAppointmentRepository
{
    private readonly AppDbContext _appDbContext;
    public AppointmentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> Count()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Appointment>> GetAllForDay(DateTime? dateTime = null)
    {
        var date = dateTime?.Date ?? DateTime.Today;  // Use today if no date is provided
        
        var dayAppointments = await _appDbContext.Appointments
            .Include(a => a.Patient)
            .Where(a => a.Date.Date == date)
            .OrderBy(a => a.Order)
            .ToListAsync();

        return dayAppointments;
    }
    public async Task<List<Appointment>> GetAllByPatientId(int patientId)
    {
        return await _appDbContext.Appointments 
            .Where(a => a.PatientId == patientId )
            .OrderByDescending(a => a.Date)
            .ToListAsync();
    }

    public async Task<int> GetMaxOrderOfDay()
    {
        var today = DateTime.Today;
    
       
        var maxOrder = await _appDbContext.Appointments
            .Where(a => a.Date.Date == today)
            .Select(a => (int?)a.Order)  // Convert to nullable int
            .MaxAsync();  // If no rows are found, return 0 as default
    
        return maxOrder ?? 0;
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
    public async Task<Appointment?> GetById(int id)
    {
        return await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == id);
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
    public async Task<Appointment?> GetAppointmentByIdIncludingPatient(int id)
    {
        var appointment = await _appDbContext.Appointments
            .Include(a => a.Patient)  // Eager load the Patient related to the Appointment
            .FirstOrDefaultAsync(a => a.AppointmentId == id); // Find the appointment by its ID

        return appointment;
    }
    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }
    
}
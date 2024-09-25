using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Repositories.Generic;
using DataAccessLayer.Repositories.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class AppointmentRepository:IAppointmentRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IPatientRepository _patientRepository;
    
    public AppointmentRepository(AppDbContext appDbContext, IPatientRepository patientRepository)
    {
        _appDbContext = appDbContext;
        _patientRepository = patientRepository;
    }

    public async Task<int> Count()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Appointment>> GetAllForDay(DateTime? dateTime)
    {
        var date = dateTime?.Date ?? DateTime.Today; 
        
        //  DbFunctions.TruncateTime to ignore the time part in the date comparison
        var dayAppointments = await _appDbContext.Appointments
            .Include(a => a.Patient)
            .Where(a => EF.Functions.DateDiffDay(a.Date, date) == 0) 
            .OrderBy(a => a.Order)
            .ToListAsync();

        return dayAppointments;
    }

    public async Task<List<Appointment>> GetAllByPatientId(string  patientId)
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
 
    public async Task<Appointment?> GetById(String id)
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
       /* var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == updatedAppointment.AppointmentId);
        var patient = await _patientRepository.GetById(updatedAppointment.PatientId);
       /* if (appointment is not null)
        {
            appointment.Status = updatedAppointment.Status;
            appointment.PatientProgress = updatedAppointment.PatientProgress;
            appointment.Order = updatedAppointment.Order;
            appointment.Date = updatedAppointment.Date;
            appointment.Note = updatedAppointment.Note;
            appointment.PatientName = updatedAppointment.PatientName;
            appointment.Patient = patient;
        }*/

     //  await _appDbContext.SaveChangesAsync();

       _appDbContext.Appointments.Update(updatedAppointment);
       await _appDbContext.SaveChangesAsync();
    }
    public async Task Delete(String id)
    {
        var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == id);
        if (appointment is not null)
        { 
            _appDbContext.Appointments.Remove(appointment);
        }
    }
    public async Task Cancel(String id)  
    {
        var appointment = await _appDbContext.Appointments
            .FirstOrDefaultAsync(a => a.AppointmentId == id);
        if (appointment is not null)
        {
            appointment.Status = Enums.AppointmentStatus.Canceled;
        }
    }
    public async Task<Appointment?> GetAppointmentByIdIncludingPatient(string id)
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
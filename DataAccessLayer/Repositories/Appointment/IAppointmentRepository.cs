using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessLayer.Entities;
public interface IAppointmentRepository
{
    Task<Appointment?> GetById(string id);
    Task Add(Appointment appointment);
    Task Update(Appointment updatedappointment);
    Task Delete(string id);
    Task<int> Count();
    Task<List<Appointment>> GetAllForDay(DateTime? dateTime);  // for doctor and time table 
    Task<List<Appointment>> GetAllByPatientId(string patientId);  // for paient profile
    Task<int> GetMaxOrderOfDay(); // when some one make appointment should be like stack 
    Task Cancel(string id);  // cancel will change stauts to canceled 
    Task SaveChanges();
    Task<Appointment?> GetAppointmentByIdIncludingPatient(string id); // egir loading 
}
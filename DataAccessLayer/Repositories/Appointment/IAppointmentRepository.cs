using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccessLayer.Entities;
public interface IAppointmentRepository
{
    Task<List<Appointment>> GetAll();
    Task<List<Appointment>> GetAllForToday();  // for doctor and time table 
    Task<List<Appointment>> GetAllByPatientId(int patientId);  // for paient profile
    Task<Appointment?> GetById(int id);     // for doctor to start write prescription
    Task<int> GetMaxOrder(); // when some one make appointment should be like stack 
    Task<bool> IsAvaliable(int doctorId);  // to show is he avalible for patient to make appointment 
    Task Add(Appointment Appointment);
    Task Update(Appointment updatedAppointment);
    Task Delete(int id);  // delet will delet from data base
    Task Cancel(int id);  // cancel will change stauts to canceled 
    Task SaveChanges();
    Task<Appointment> GetAppointmentByIdIncludingPatient(int id);
    
    
}
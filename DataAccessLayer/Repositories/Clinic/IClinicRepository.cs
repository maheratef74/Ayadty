namespace DataAccessLayer.Repositories.Clinic;



using DataAccessLayer.Entities;
public interface IClinicRepository
{
    Task<Clinic?> GetById(string clinicId);
    Task Update(Clinic updatedclinic);
    Task OpenNewAppointments();
    Task StopNewAppointments();
    Task<bool> IsAvailabelToAppointments();
    Task SaveChanges();
    
    Task<Clinic> GetClinicByIdAsync(string id); 
    Task UpdateClinicAsync(Clinic clinic);



}

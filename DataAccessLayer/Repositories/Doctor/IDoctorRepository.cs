namespace DataAccessLayer.Repositories.Doctor;
using DataAccessLayer.Entities;
public interface IDoctorRepository
{
    Task<Doctor?>GetById(string DoctorId);
    Task<Doctor?> GetDoctorByPhoneNUmber(string phoneNumber);
    Task Add(Doctor doctor);

    Task Update(Doctor doctor);


    Task SaveChange();

    
 
}
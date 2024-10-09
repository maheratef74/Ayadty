namespace DataAccessLayer.Repositories.Clinic;



using DataAccessLayer.Entities;
public interface IClinicRepository
{
    Task<CliniC?> GetById(string clinicId);
    Task Update(CliniC updatedclinic);
    Task SaveChanges();





    Task<CliniC> GetClinicByIdAsync(string id); // تغيير النوع إلى string
    Task UpdateClinicAsync(CliniC clinic);



}

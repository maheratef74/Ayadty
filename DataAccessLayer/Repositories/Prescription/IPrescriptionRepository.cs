namespace DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Entities;
public interface IPrescriptionRepository
{
    Task Add(Prescription prescription);
    Task<Prescription?> GetPrescriptionById(string prescriptionId);
    Task SaveChanges();
}
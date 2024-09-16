namespace DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Entities;
public interface IPrescriptionRepository
{
    Task Add(Prescription prescription);

    Task SaveChanges();
}
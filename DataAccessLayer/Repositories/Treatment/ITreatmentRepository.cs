namespace DataAccessLayer.Repositories.Treatment;
using DataAccessLayer.Entities;
public interface ITreatmentRepository
{
    Task Add(Treatment treatment);

    Task SaveChanges();
}
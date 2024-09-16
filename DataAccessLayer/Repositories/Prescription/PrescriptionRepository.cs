using DataAccessLayer.Repositories.Treatment;

namespace DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Entities;
public class PrescriptionRepository:IPrescriptionRepository
{
    private readonly AppDbContext _appContext;
    private readonly ITreatmentRepository _treatmentRepository;
    public PrescriptionRepository(AppDbContext appContext, ITreatmentRepository treatmentRepository)
    {
        _appContext = appContext;
        _treatmentRepository = treatmentRepository;
    }
    public async Task Add(Prescription prescription)
    {
        foreach (var treatment in prescription.Treatments)
        {
            await _treatmentRepository.Add(treatment);
        }
        await _appContext.Prescriptions.AddAsync(prescription);
    }
    public async Task SaveChanges()
    {
       await _appContext.SaveChangesAsync();
    }
}
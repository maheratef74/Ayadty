using DataAccessLayer.Repositories.Treatment;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Prescription?> GetPrescriptionById(string prescriptionId)
    {
        
        var prescription = await _appContext.Prescriptions
            .FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);

        if (prescription == null)
        {
            return null; 
        }

        var treatments = await _appContext.Treatments
            .Where(t => t.PrescriptionId == prescriptionId)
            .ToListAsync();

        prescription.Treatments = treatments;
        
        return prescription;
    }

    public async Task SaveChanges()
    {
       await _appContext.SaveChangesAsync();
    }
}
using DataAccessLayer.Repositories.Patient;
using DataAccessLayer.Repositories.Treatment;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Prescription;
using DataAccessLayer.Entities;
public class PrescriptionRepository:IPrescriptionRepository
{
    private readonly AppDbContext _appContext;
    private readonly ITreatmentRepository _treatmentRepository;
    private readonly IPatientRepository _patientRepository;
    public PrescriptionRepository(AppDbContext appContext, ITreatmentRepository treatmentRepository, IPatientRepository patientRepository)
    {
        _appContext = appContext;
        _treatmentRepository = treatmentRepository;
        _patientRepository = patientRepository;
    }
    public async Task Add(Prescription prescription)
    {
        var appointment =
            await _appContext.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == prescription.AppointmentId);
        
        // change status of appointment and patient Progress
        appointment.Status = Enums.AppointmentStatus.Completed;
        appointment.PatientProgress = Enums.PatientProgress.InClinic;
        
        // add completed appointment to patient profile 
        var patient = await _patientRepository.GetById(appointment.PatientId);
        patient.CompletedAppointments++;
        
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

    public async Task UpdatePrescription(Prescription updatedprescription)
    {
        var prescription = await _appContext.Prescriptions
            .FirstOrDefaultAsync( p => p.PrescriptionId == updatedprescription.PrescriptionId);

        if (prescription is not null)
        {
            prescription.Diagnosis = updatedprescription.Diagnosis;
            prescription.PatientName = updatedprescription.PatientName;
            prescription.Date = updatedprescription.Date;
            prescription.Notes = updatedprescription.Notes;
            prescription.patientAge = updatedprescription.patientAge;
            
            // now i collect the old treatment to  delete them
            var OldTreatments = await _appContext.Treatments
                .Where(t => t.PrescriptionId == prescription.PrescriptionId)
                .ToListAsync();
            
            _appContext.Treatments.RemoveRange(OldTreatments);
           
            //set the prescriptionId to the new treatment and add the new treatment
            foreach (var treatment in updatedprescription.Treatments)
            {
                treatment.PrescriptionId = updatedprescription.PrescriptionId;
                await _treatmentRepository.Add(treatment);
            }
        }
    }

    public async Task<List<Prescription>> GetPrescriptionsByAppointmentId(string appointmentId)
    {
        var prescriptions = await _appContext.Prescriptions
         //   .Include(p => p.Treatments) // Eager load treatments
            .Where(p => p.AppointmentId == appointmentId) 
            .ToListAsync();

        return prescriptions;
    }

    public async Task SaveChanges()
    {
       await _appContext.SaveChangesAsync();
    }
}
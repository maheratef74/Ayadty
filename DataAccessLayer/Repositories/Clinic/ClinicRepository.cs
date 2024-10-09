﻿using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Clinic;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Patient;
using Microsoft.EntityFrameworkCore;

public class ClinicRepository : IClinicRepository
{
    private readonly AppDbContext _appDbContext;
    public ClinicRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
       
    }
    public async Task<Clinic?> GetById(string clinicId)
    {
        var clinic = await _appDbContext.Clinic
            .FirstOrDefaultAsync(p => p.ClinicId == clinicId);

        return clinic;
    }
    public async Task Update(Clinic updatedClinic)
    {
        var clinic = await _appDbContext.Clinic
             .FirstOrDefaultAsync(a => a.ClinicId == updatedClinic.ClinicId);

        if (clinic is not null)
        {
            clinic.Name = updatedClinic.Name;
            clinic.PhoneNumber = updatedClinic.PhoneNumber;
            clinic.Email = updatedClinic.Email;
            clinic.Location = updatedClinic.Location;
        }
    }

    public async Task OpenNewAppointments()
    {
        var clinic = await _appDbContext.Clinic.FirstOrDefaultAsync();
        clinic.IsAvalibleToAppoinment = true;
    }

    public async Task StopNewAppointments()
    {
        var clinic = await _appDbContext.Clinic.FirstOrDefaultAsync();
        clinic.IsAvalibleToAppoinment = false;
    }

    public async Task<bool> IsAvailabelToAppointments()
    {
        var clinic = await _appDbContext.Clinic.FirstOrDefaultAsync();
        
        return clinic.IsAvalibleToAppoinment;
    }

    public async Task SaveChanges()
    {
        await _appDbContext.SaveChangesAsync();
    }

    
    public async Task<Clinic> GetClinicByIdAsync(string id) 
    {
        return await _appDbContext.Clinic.FindAsync(id); 
    }

    public async Task UpdateClinicAsync(Clinic clinic)
    {
        _appDbContext.Clinic.Update(clinic);
    }
}
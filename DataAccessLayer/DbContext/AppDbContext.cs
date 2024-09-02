using Ayadty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Clinic> Clinic { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<WorkDay> WorkDays { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
}


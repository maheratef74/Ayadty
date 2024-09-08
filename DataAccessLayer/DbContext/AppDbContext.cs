using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .Property(d => d.Price)
            .HasPrecision(18, 2);
    }
    // DbSets
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Clinic> Clinic { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<WorkDay> WorkDays { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
}


using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbContext :  IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<Doctor>()
            .Property(d => d.Price)
            .HasPrecision(18, 2);
       
        // change names of tables that identity make it 
        modelBuilder.Entity<IdentityUser>(e => e.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(e => e.ToTable("Roles"));
        
        
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


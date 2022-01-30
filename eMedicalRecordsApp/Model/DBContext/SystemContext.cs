using eMedicalRecordsApp.Configuration;
using Microsoft.EntityFrameworkCore;

namespace eMedicalRecordsApp.Model.DBContext;

public class SystemContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Ambulance> Ambulances { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Diagnosis> Diagnosis { get; set; }
    public DbSet<AssignedDiagnosis> AssignedDiagnoses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseSqlite("Data Source=System.db;");
        optionsBuilder.LogTo(Console.WriteLine);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PatientConfig());
        modelBuilder.Entity<Patient>()
            .HasMany<Doctor>(d => d.CanAccess)
            .WithMany(p => p.PatientsCanAccess)
            .UsingEntity(t => t.ToTable("CanAccess"));

        modelBuilder.Entity<Patient>()
            .HasOne<Doctor>(p => p.Doctor)
            .WithMany(d => d.Patients);
    }
    
    
}
using eMedicalRecordsApp.Model.DBContext.Configuration;
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
    public DbSet<User> Users { get; set; }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataConfig).Assembly);
    }
}
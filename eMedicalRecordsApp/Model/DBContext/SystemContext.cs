using Microsoft.EntityFrameworkCore;

namespace eMedicalRecordsApp.Model.DBContext;

public class SystemContext: DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<UrgentInfo> UrgentInfos { get; set; }
    public DbSet<Anamnesis> Anamnesis { get; set; }
    public DbSet<Ambulance> Ambulances { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
}
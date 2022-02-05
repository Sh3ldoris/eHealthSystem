using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMedicalRecordsApp.Model.DBContext.Configuration;

public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.OwnsOne(p => p.Anamnesis);
        builder.OwnsOne(p => p.UrgentInfo);
        
        builder
            .HasMany<Doctor>(d => d.CanAccess)
            .WithMany(p => p.PatientsCanAccess)
            .UsingEntity(t => t.ToTable("CanAccess"));
        
        builder
            .HasOne<Doctor>(p => p.Doctor)
            .WithMany(d => d.Patients);
    }
}
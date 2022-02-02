using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMedicalRecordsApp.Model.DBContext.Configuration;

public class PatientConfig : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.OwnsOne(p => p.Anamnesis);
        builder.OwnsOne(p => p.UrgentInfo);
    }
}
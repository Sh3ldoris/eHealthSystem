using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMedicalRecordsApp.Model.DBContext.Configuration;

public class DataConfig : 
    IEntityTypeConfiguration<Person>, 
    IEntityTypeConfiguration<Ambulance>, 
    IEntityTypeConfiguration<Doctor>, 
    IEntityTypeConfiguration<Diagnosis>,
    IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasData(new Person(
            "doctor/1",
            "MUDr. Vladimír",
            "Kucko",
            "MALE",
            new DateTime(1998, 10, 10),
            "Predajna",
            "112",
            "Slovbodny",
            "Pracant"
        ));

        builder.HasData(new Person(
            "doctor/2",
            "MUDr. Elena",
            "Auxtova",
            "FEMALE",
            new DateTime(1998, 10, 10),
            "Predajna",
            "112",
            "Slovbodny",
            "Pracant"
        ));
    }

    public void Configure(EntityTypeBuilder<Ambulance> builder)
    {
        builder.HasData(new {
            Id = 1,
            Name = "O Č N Á   A M B U L A N C I A",
            Address = "ul. V. Spanyola 43, Žilina 010 01"
            });
        
        builder.HasData(new {
            Id = 2,
            Name = "Všeobecná ambulancia pre deti a dorast, Valaská",
            Address = "Štúrova  481/5 97646  Valaská"
        });
    }

    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData(new
        {
            PersonalNumber = "5ZY0123",
            PersonBirthNumber = "doctor/1",
            Specification = "oftalmológ",
            AmbulanceId = 1
        });
        
        builder.HasData(new
        {
            PersonalNumber = "5ZY0153",
            PersonBirthNumber = "doctor/2",
            Specification = "všeobecná starostlivosť o deti a dorast",
            AmbulanceId = 2
        });
    }
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new
        {
            Code = Guid.NewGuid(),
            Password = "Pass123",
            UserDoctorPersonalNumber = "5ZY0123"
        });
        
        builder.HasData(new
        {
            Code = Guid.NewGuid(),
            Password = "Pass123",
            UserDoctorPersonalNumber = "5ZY0153"
        });
    }

    public void Configure(EntityTypeBuilder<Diagnosis> builder)
    {
        builder.HasData(new Diagnosis("A02", "Iné infekcie salmonelami"));
        builder.HasData(new Diagnosis("A03", "Bacilová červienka (dyzentéria) – šigelóza"));
        builder.HasData(new Diagnosis("A04", "Iné bakteriálne črevné infekcie"));
    }
}
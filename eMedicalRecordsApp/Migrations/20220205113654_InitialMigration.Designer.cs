// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eMedicalRecordsApp.Model.DBContext;

#nullable disable

namespace eMedicalRecordsApp.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20220205113654_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.Property<string>("CanAccessPersonalNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientsCanAccessCode")
                        .HasColumnType("TEXT");

                    b.HasKey("CanAccessPersonalNumber", "PatientsCanAccessCode");

                    b.HasIndex("PatientsCanAccessCode");

                    b.ToTable("CanAccess", (string)null);
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Ambulance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ambulances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ul. V. Spanyola 43, Žilina 010 01",
                            Name = "O Č N Á   A M B U L A N C I A"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Štúrova  481/5 97646  Valaská",
                            Name = "Všeobecná ambulancia pre deti a dorast, Valaská"
                        });
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.AssignedDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DiagnosisCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HealthRecordId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Localization")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisCode");

                    b.HasIndex("HealthRecordId");

                    b.ToTable("AssignedDiagnoses");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Diagnosis", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Diagnosis");

                    b.HasData(
                        new
                        {
                            Code = "A02",
                            Name = "Iné infekcie salmonelami"
                        },
                        new
                        {
                            Code = "A03",
                            Name = "Bacilová červienka (dyzentéria) – šigelóza"
                        },
                        new
                        {
                            Code = "A04",
                            Name = "Iné bakteriálne črevné infekcie"
                        });
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Doctor", b =>
                {
                    b.Property<string>("PersonalNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("AmbulanceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PersonBirthNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Specification")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonalNumber");

                    b.HasIndex("AmbulanceId");

                    b.HasIndex("PersonBirthNumber");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            PersonalNumber = "5ZY0123",
                            AmbulanceId = 1,
                            PersonBirthNumber = "doctor/1",
                            Specification = "oftalmológ"
                        },
                        new
                        {
                            PersonalNumber = "5ZY0153",
                            AmbulanceId = 2,
                            PersonBirthNumber = "doctor/2",
                            Specification = "všeobecná starostlivosť o deti a dorast"
                        });
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.HealthRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoctorPersonalNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoctorPersonalNumber");

                    b.HasIndex("PatientCode");

                    b.ToTable("HealthRecords");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Patient", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("DoctorPersonalNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Insurance")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonBirthNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.HasIndex("DoctorPersonalNumber");

                    b.HasIndex("PersonBirthNumber");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Person", b =>
                {
                    b.Property<string>("BirthNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FamilyState")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Occupation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BirthNumber");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            BirthNumber = "doctor/1",
                            Address = "Predajna",
                            BirthDate = new DateTime(1998, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FamilyState = "Slovbodny",
                            FirstName = "MUDr. Vladimír",
                            Gender = "MALE",
                            LastName = "Kucko",
                            Occupation = "Pracant",
                            Phone = "112"
                        },
                        new
                        {
                            BirthNumber = "doctor/2",
                            Address = "Predajna",
                            BirthDate = new DateTime(1998, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FamilyState = "Slovbodny",
                            FirstName = "MUDr. Elena",
                            Gender = "FEMALE",
                            LastName = "Auxtova",
                            Occupation = "Pracant",
                            Phone = "112"
                        });
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.User", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserDoctorPersonalNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.HasIndex("UserDoctorPersonalNumber");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Code = new Guid("5dcd99cf-0670-4ad2-ae0b-1fa4f202b938"),
                            Password = "Pass123",
                            UserDoctorPersonalNumber = "5ZY0123"
                        },
                        new
                        {
                            Code = new Guid("8178ca81-97cd-4c78-a4c1-f03e4b810ccd"),
                            Password = "Pass123",
                            UserDoctorPersonalNumber = "5ZY0153"
                        });
                });

            modelBuilder.Entity("DoctorPatient", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Doctor", null)
                        .WithMany()
                        .HasForeignKey("CanAccessPersonalNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMedicalRecordsApp.Model.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsCanAccessCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.AssignedDiagnosis", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMedicalRecordsApp.Model.HealthRecord", null)
                        .WithMany("Diagnosis")
                        .HasForeignKey("HealthRecordId");

                    b.Navigation("Diagnosis");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Doctor", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Ambulance", "Ambulance")
                        .WithMany()
                        .HasForeignKey("AmbulanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMedicalRecordsApp.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonBirthNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ambulance");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.HealthRecord", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorPersonalNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMedicalRecordsApp.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Patient", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorPersonalNumber");

                    b.HasOne("eMedicalRecordsApp.Model.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonBirthNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("eMedicalRecordsApp.Model.Anamnesis", "Anamnesis", b1 =>
                        {
                            b1.Property<string>("PatientCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Abuses")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("CurrentDiseases")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("FamilyAnamnesis")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("GynecologicalHistory")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PharmacologyHistory")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PhysiologicalFunctions")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PreviousPeriod")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("PatientCode");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientCode");
                        });

                    b.OwnsOne("eMedicalRecordsApp.Model.UrgentInfo", "UrgentInfo", b1 =>
                        {
                            b1.Property<string>("PatientCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Allergies")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("BloodGroup")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<long>("Height")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Infections")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("OrganDonation")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("OtherRisks")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PermanentMedicals")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Tetanus")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Transplantation")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<long>("Weight")
                                .HasColumnType("INTEGER");

                            b1.HasKey("PatientCode");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientCode");
                        });

                    b.Navigation("Anamnesis");

                    b.Navigation("Doctor");

                    b.Navigation("Person");

                    b.Navigation("UrgentInfo");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.User", b =>
                {
                    b.HasOne("eMedicalRecordsApp.Model.Doctor", "UserDoctor")
                        .WithMany()
                        .HasForeignKey("UserDoctorPersonalNumber");

                    b.Navigation("UserDoctor");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.Doctor", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("eMedicalRecordsApp.Model.HealthRecord", b =>
                {
                    b.Navigation("Diagnosis");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMedicalRecordsApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambulances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambulances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosis", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    BirthNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyState = table.Column<string>(type: "TEXT", nullable: true),
                    Occupation = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.BirthNumber);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    PersonalNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PersonBirthNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Specification = table.Column<string>(type: "TEXT", nullable: false),
                    AmbulanceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.PersonalNumber);
                    table.ForeignKey(
                        name: "FK_Doctors_Ambulances_AmbulanceId",
                        column: x => x.AmbulanceId,
                        principalTable: "Ambulances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Persons_PersonBirthNumber",
                        column: x => x.PersonBirthNumber,
                        principalTable: "Persons",
                        principalColumn: "BirthNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Insurance = table.Column<string>(type: "TEXT", nullable: false),
                    PersonBirthNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UrgentInfo_Allergies = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_OtherRisks = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_PermanentMedicals = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_Infections = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_OrganDonation = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_Height = table.Column<long>(type: "INTEGER", nullable: true),
                    UrgentInfo_Weight = table.Column<long>(type: "INTEGER", nullable: true),
                    UrgentInfo_Tetanus = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UrgentInfo_Transplantation = table.Column<string>(type: "TEXT", nullable: true),
                    UrgentInfo_BloodGroup = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_CurrentDiseases = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_PreviousPeriod = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_PharmacologyHistory = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_Abuses = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_PhysiologicalFunctions = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_GynecologicalHistory = table.Column<string>(type: "TEXT", nullable: true),
                    Anamnesis_FamilyAnamnesis = table.Column<string>(type: "TEXT", nullable: true),
                    DoctorPersonalNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorPersonalNumber",
                        column: x => x.DoctorPersonalNumber,
                        principalTable: "Doctors",
                        principalColumn: "PersonalNumber");
                    table.ForeignKey(
                        name: "FK_Patients_Persons_PersonBirthNumber",
                        column: x => x.PersonBirthNumber,
                        principalTable: "Persons",
                        principalColumn: "BirthNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Code = table.Column<Guid>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserDoctorPersonalNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Users_Doctors_UserDoctorPersonalNumber",
                        column: x => x.UserDoctorPersonalNumber,
                        principalTable: "Doctors",
                        principalColumn: "PersonalNumber");
                });

            migrationBuilder.CreateTable(
                name: "CanAccess",
                columns: table => new
                {
                    CanAccessPersonalNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PatientsCanAccessCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanAccess", x => new { x.CanAccessPersonalNumber, x.PatientsCanAccessCode });
                    table.ForeignKey(
                        name: "FK_CanAccess_Doctors_CanAccessPersonalNumber",
                        column: x => x.CanAccessPersonalNumber,
                        principalTable: "Doctors",
                        principalColumn: "PersonalNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanAccess_Patients_PatientsCanAccessCode",
                        column: x => x.PatientsCanAccessCode,
                        principalTable: "Patients",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DoctorPersonalNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PatientCode = table.Column<string>(type: "TEXT", nullable: false),
                    Report = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Doctors_DoctorPersonalNumber",
                        column: x => x.DoctorPersonalNumber,
                        principalTable: "Doctors",
                        principalColumn: "PersonalNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Patients_PatientCode",
                        column: x => x.PatientCode,
                        principalTable: "Patients",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedDiagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Localization = table.Column<string>(type: "TEXT", nullable: true),
                    DiagnosisCode = table.Column<string>(type: "TEXT", nullable: false),
                    HealthRecordId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedDiagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedDiagnoses_Diagnosis_DiagnosisCode",
                        column: x => x.DiagnosisCode,
                        principalTable: "Diagnosis",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedDiagnoses_HealthRecords_HealthRecordId",
                        column: x => x.HealthRecordId,
                        principalTable: "HealthRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Ambulances",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "ul. V. Spanyola 43, Žilina 010 01", "O Č N Á   A M B U L A N C I A" });

            migrationBuilder.InsertData(
                table: "Ambulances",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 2, "Štúrova  481/5 97646  Valaská", "Všeobecná ambulancia pre deti a dorast, Valaská" });

            migrationBuilder.InsertData(
                table: "Diagnosis",
                columns: new[] { "Code", "Name" },
                values: new object[] { "A02", "Iné infekcie salmonelami" });

            migrationBuilder.InsertData(
                table: "Diagnosis",
                columns: new[] { "Code", "Name" },
                values: new object[] { "A03", "Bacilová červienka (dyzentéria) – šigelóza" });

            migrationBuilder.InsertData(
                table: "Diagnosis",
                columns: new[] { "Code", "Name" },
                values: new object[] { "A04", "Iné bakteriálne črevné infekcie" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "BirthNumber", "Address", "BirthDate", "FamilyState", "FirstName", "Gender", "LastName", "Occupation", "Phone" },
                values: new object[] { "doctor/1", "Predajna", new DateTime(1998, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovbodny", "MUDr. Vladimír", "MALE", "Kucko", "Pracant", "112" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "BirthNumber", "Address", "BirthDate", "FamilyState", "FirstName", "Gender", "LastName", "Occupation", "Phone" },
                values: new object[] { "doctor/2", "Predajna", new DateTime(1998, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovbodny", "MUDr. Elena", "FEMALE", "Auxtova", "Pracant", "112" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "PersonalNumber", "AmbulanceId", "PersonBirthNumber", "Specification" },
                values: new object[] { "5ZY0123", 1, "doctor/1", "oftalmológ" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "PersonalNumber", "AmbulanceId", "PersonBirthNumber", "Specification" },
                values: new object[] { "5ZY0153", 2, "doctor/2", "všeobecná starostlivosť o deti a dorast" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Code", "Password", "UserDoctorPersonalNumber" },
                values: new object[] { new Guid("5dcd99cf-0670-4ad2-ae0b-1fa4f202b938"), "Pass123", "5ZY0123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Code", "Password", "UserDoctorPersonalNumber" },
                values: new object[] { new Guid("8178ca81-97cd-4c78-a4c1-f03e4b810ccd"), "Pass123", "5ZY0153" });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDiagnoses_DiagnosisCode",
                table: "AssignedDiagnoses",
                column: "DiagnosisCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDiagnoses_HealthRecordId",
                table: "AssignedDiagnoses",
                column: "HealthRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAccess_PatientsCanAccessCode",
                table: "CanAccess",
                column: "PatientsCanAccessCode");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AmbulanceId",
                table: "Doctors",
                column: "AmbulanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PersonBirthNumber",
                table: "Doctors",
                column: "PersonBirthNumber");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_DoctorPersonalNumber",
                table: "HealthRecords",
                column: "DoctorPersonalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_PatientCode",
                table: "HealthRecords",
                column: "PatientCode");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorPersonalNumber",
                table: "Patients",
                column: "DoctorPersonalNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PersonBirthNumber",
                table: "Patients",
                column: "PersonBirthNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDoctorPersonalNumber",
                table: "Users",
                column: "UserDoctorPersonalNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedDiagnoses");

            migrationBuilder.DropTable(
                name: "CanAccess");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Ambulances");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

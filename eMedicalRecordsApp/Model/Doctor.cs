using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string PersonalNumber { get; set; }
    
    [Required]
    public virtual Person Person { get; set; }
    [Required]
    public string Specification { get; set; }
    [Required]
    public virtual Ambulance Ambulance { get; set; }
    [AllowNull]
    public virtual List<Patient>? Patients { get; set; }
    [AllowNull]
    public virtual List<Patient>? PatientsCanAccess { get; set; }

    public Doctor(string personalNumber, Person person, string specification, Ambulance ambulance, List<Patient>? patients, List<Patient>? patientsCanAccess)
    {
        PersonalNumber = personalNumber;
        Person = person;
        Specification = specification;
        Ambulance = ambulance;
        Patients = patients;
        PatientsCanAccess = patientsCanAccess;
    }

    public Doctor()
    {
    }
}
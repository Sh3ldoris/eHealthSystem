using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Code { get; set; }
    [Required]
    public string Insurance { get; set; }
    [Required]
    public virtual Person Person { get; set; }
    [AllowNull]
    public virtual UrgentInfo? UrgentInfo { get; set; }
    [AllowNull]
    public virtual Anamnesis? Anamnesis { get; set; }
    
    [AllowNull]
    public virtual Doctor? Doctor { get; set; }
    [Required]
    public virtual List<Doctor> CanAccess { get; set; }

    public Patient(string code, string insurance, Person person, UrgentInfo? urgentInfo, Anamnesis? anamnesis, Doctor? doctor, List<Doctor>? canAccess)
    {
        Code = code;
        Insurance = insurance;
        Person = person;
        UrgentInfo = urgentInfo;
        Anamnesis = anamnesis;
        Doctor = doctor;
        CanAccess = canAccess?? new List<Doctor>();
    }

    public Patient()
    {
    }
}
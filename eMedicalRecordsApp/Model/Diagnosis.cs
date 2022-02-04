using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class Diagnosis
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }

    public Diagnosis(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public Diagnosis()
    {
        Code = "";
        Name = "";
    }
}

public class AssignedDiagnosis
{
    [Key]
    public int Id { get; set; }
    [AllowNull]
    public string? Localization { get; set; }
    [Required]
    public virtual Diagnosis Diagnosis { get; set; }

    public AssignedDiagnosis(string? localization, Diagnosis diagnosis)
    {
        Localization = localization;
        Diagnosis = diagnosis;
    }

    public AssignedDiagnosis()
    {
    }
}
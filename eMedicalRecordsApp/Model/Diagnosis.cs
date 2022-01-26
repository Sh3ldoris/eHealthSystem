using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class Diagnosis
{
    [Key]
    public string Code { get; set; }
    public string Name { get; set; }
}

public class AssignedDiagnosis
{
    [Key]
    public int Id { get; set; }
    public string Localization { get; set; }
    public Diagnosis Diagnosis { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMedicalRecordsApp.Model;

public class Diagnosis
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Code { get; set; }
    public string Name { get; set; }

    public Diagnosis()
    {
    }
}

public class AssignedDiagnosis
{
    [Key]
    public int Id { get; set; }
    public string Localization { get; set; }
    public virtual Diagnosis Diagnosis { get; set; }

    public AssignedDiagnosis()
    {
    }
}
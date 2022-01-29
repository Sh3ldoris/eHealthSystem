using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMedicalRecordsApp.Model;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string Code { get; set; }
    public string Insurance { get; set; }
    public virtual Person Person { get; set; }
    public virtual UrgentInfo? UrgentInfo { get; set; }
    public virtual Anamnesis? Anamnesis { get; set; }
    public virtual Doctor? Doctor { get; set; }
    public virtual List<Doctor> CanAccess { get; set; }

    public Patient()
    {
    }
}
using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class HealthRecord
{
    [Key]
    public int Id { get; set; }
    public string PatientCode { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public virtual Doctor Doctor { get; set; }
    public string Report { get; set; }
    public virtual AssignedDiagnosis diagnosis { get; set; }

    public HealthRecord()
    {
    }
}
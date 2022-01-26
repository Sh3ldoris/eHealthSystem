using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class HealthRecord
{
    [Key]
    public int Id { get; set; }
    public string PatientCode { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public Doctor Doctor { get; set; }
    public string Report { get; set; }
    public AssignedDiagnosis diagnosis { get; set; }
}
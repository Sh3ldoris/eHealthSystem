using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class HealthRecord
{
    [Key]
    public string Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public virtual Doctor Doctor { get; set; }
    [Required]
    public virtual Patient Patient { get; set; }
    [Required]
    public string Report { get; set; }
    [AllowNull]
    public virtual List<AssignedDiagnosis>? Diagnosis { get; set; }

    public HealthRecord(string id, DateTime date, string title, Doctor doctor, Patient patient, string report, List<AssignedDiagnosis>? diagnosis)
    {
        Id = id;
        Date = date;
        Title = title;
        Doctor = doctor;
        Patient = patient;
        Report = report;
        Diagnosis = diagnosis;
    }

    public HealthRecord()
    {
    }
}
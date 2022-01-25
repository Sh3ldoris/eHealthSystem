namespace eMedicalRecordsApp.Model;

public class HealthRecord
{
    public string PatientCode { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public Doctor Doctor { get; set; }
    public string Report { get; set; }
    public AssignedDiagnosis diagnosis { get; set; }
}
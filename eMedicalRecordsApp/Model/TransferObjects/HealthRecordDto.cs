namespace eMedicalRecordsApp.Model.TransferObjects;

public record HealthRecordDto
{
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public virtual Doctor Doctor { get; set; }
    public string PatientCode { get; set; }
    public string Report { get; set; }
    public virtual List<AssignedDiagnosisDto> Diagnosis { get; set; }

    public HealthRecordDto(DateTime date, string title, Doctor doctor, string patientCode, string report, List<AssignedDiagnosisDto> diagnosis)
    {
        Date = date;
        Title = title;
        Doctor = doctor;
        PatientCode = patientCode;
        Report = report;
        Diagnosis = diagnosis;
    }

    public HealthRecordDto()
    {
    }
}
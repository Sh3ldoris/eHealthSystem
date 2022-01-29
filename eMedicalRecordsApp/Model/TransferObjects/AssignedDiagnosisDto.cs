namespace eMedicalRecordsApp.Model.TransferObjects;

public record AssignedDiagnosisDto
{
    public string Localization { get; set; }
    public virtual Diagnosis Diagnosis { get; set; }

    public AssignedDiagnosisDto(string localization, Diagnosis diagnosis)
    {
        Localization = localization;
        Diagnosis = diagnosis;
    }

    public AssignedDiagnosisDto()
    {
    }
}
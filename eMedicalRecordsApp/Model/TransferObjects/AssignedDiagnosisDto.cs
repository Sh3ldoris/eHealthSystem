using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model.TransferObjects;

public record AssignedDiagnosisDto
{
    public string? Localization { get; set; }
    [Required]
    public Diagnosis Diagnosis { get; set; }

    public AssignedDiagnosisDto(string? localization, Diagnosis diagnosis)
    {
        Localization = localization;
        Diagnosis = diagnosis;
    }
}
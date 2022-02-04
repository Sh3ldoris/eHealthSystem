using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class Anamnesis
{
    [AllowNull]
    public string CurrentDiseases { get; set; }
    [AllowNull]
    public string PreviousPeriod { get; set; }
    [AllowNull]
    public string PharmacologyHistory { get; set; }
    [AllowNull]
    public string Abuses { get; set; }
    [AllowNull]
    public string PhysiologicalFunctions { get; set; }
    [AllowNull]
    public string GynecologicalHistory { get; set; }
    [AllowNull]
    public string FamilyAnamnesis { get; set; }

    public Anamnesis()
    {
    }
}
using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class Anamnesis
{
    [Key]
    public int Id { get; set; }
    public string CurrentDiseases { get; set; }
    public string PreviousPeriod { get; set; }
    public string PharmacologyHistory { get; set; }
    public string Abuses { get; set; }
    public string PhysiologicalFunctions { get; set; }
    public string GynecologicalHistory { get; set; }
    public string FamilyAnamnesis { get; set; }
}
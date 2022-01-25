namespace eMedicalRecordsApp.Model;

public class Diagnosis
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class AssignedDiagnosis
{
    public string Localization { get; set; }
    public Diagnosis Diagnosis { get; set; }
}
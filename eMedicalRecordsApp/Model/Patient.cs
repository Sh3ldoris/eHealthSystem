using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class Patient
{
    [Key]
    public string Code { get; set; }
    public string Insurance { get; set; }
    public Person Person { get; set; }
    public UrgentInfo UrgentInfo { get; set; }
    public Anamnesis Anamnesis { get; set; }
    public Doctor Doctor { get; set; }
    public List<Doctor> CanAccess { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class UrgentInfo
{
    [Key]
    public int Id { get; set; }
    public string Allergies { get; set; }
    public string OtherRisks { get; set; }
    public string PermanentMedicals { get; set; }
    public string infections { get; set; }
    public string OrganDonation { get; set; }
    public long Height { get; set; }
    public long Weight { get; set; }
    public DateTime Tetanus { get; set; }
    public string Transplantation { get; set; }
    public string BloodGroup { get; set; }
}
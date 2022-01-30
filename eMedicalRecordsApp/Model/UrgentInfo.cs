using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class UrgentInfo
{
    public string Allergies { get; set; }
    public string OtherRisks { get; set; }
    public string PermanentMedicals { get; set; }
    public string infections { get; set; }
    public string OrganDonation { get; set; }
    public long Height { get; set; }
    public long Weight { get; set; }
    [AllowNull]
    public DateTime? Tetanus { get; set; }
    public string Transplantation { get; set; }
    public string BloodGroup { get; set; }

    public UrgentInfo()
    {
    }
}
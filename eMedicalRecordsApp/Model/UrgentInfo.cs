using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class UrgentInfo
{
    [AllowNull]
    public string Allergies { get; set; }
    [AllowNull]
    public string OtherRisks { get; set; }
    [AllowNull]
    public string PermanentMedicals { get; set; }
    [AllowNull]
    public string Infections { get; set; }
    [AllowNull]
    public string OrganDonation { get; set; }
    [AllowNull]
    public long Height { get; set; }
    [AllowNull]
    public long Weight { get; set; }
    [AllowNull]
    public DateTime? Tetanus { get; set; }
    [AllowNull]
    public string Transplantation { get; set; }
    [AllowNull]
    public string BloodGroup { get; set; }

    public UrgentInfo()
    {
    }
}
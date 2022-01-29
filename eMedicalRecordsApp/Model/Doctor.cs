using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMedicalRecordsApp.Model;

public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string PersonalNumber { get; set; }
    public string Password { get; set; }
    public virtual Person Person { get; set; }
    public string Specification { get; set; }
    public virtual Ambulance Ambulance { get; set; }

    public Doctor()
    {
    }
}
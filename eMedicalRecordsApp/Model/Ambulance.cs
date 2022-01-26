using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class Ambulance
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
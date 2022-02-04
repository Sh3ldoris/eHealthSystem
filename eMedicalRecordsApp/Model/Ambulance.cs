using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class Ambulance
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }

    public Ambulance(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public Ambulance()
    {
        Name = "";
        Address = "";
    }
}
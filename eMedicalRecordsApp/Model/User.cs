using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class User
{
    [Key]
    public Guid Code { get; set; }
    public string Password { get; set; }
    public Doctor UserDoctor { get; set; }

    public User()
    {
    }
}
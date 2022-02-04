using System.ComponentModel.DataAnnotations;

namespace eMedicalRecordsApp.Model;

public class User
{
    [Key]
    public Guid Code { get; set; }
    [Required]
    public string Password { get; set; }
    public virtual Doctor UserDoctor { get; set; }

    public User(string password, Doctor userDoctor)
    {
        Password = password;
        UserDoctor = userDoctor;
    }

    public User()
    {
    }
}
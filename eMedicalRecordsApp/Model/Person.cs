using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMedicalRecordsApp.Model;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string BirthNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string FamilyState { get; set; }
    public string Occupation { get; set; }

    public Person()
    {
    }
}
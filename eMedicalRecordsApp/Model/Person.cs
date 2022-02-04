using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace eMedicalRecordsApp.Model;

public class Person
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string BirthNumber { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }
    [AllowNull]
    public string? FamilyState { get; set; }
    [AllowNull]
    public string? Occupation { get; set; }

    public Person(string birthNumber, string firstName, string lastName, string gender, DateTime birthDate, string address, string phone, string? familyState, string? occupation)
    {
        BirthNumber = birthNumber;
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BirthDate = birthDate;
        Address = address;
        Phone = phone;
        FamilyState = familyState;
        Occupation = occupation;
    }

    public Person()
    {
        BirthNumber = "";
        FirstName = "";
        LastName = "";
        Gender = "";
        BirthDate = new DateTime();
        Address = "";
        Phone = "";
    }
}
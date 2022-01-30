namespace eMedicalRecordsApp.Model.TransferObjects;

public record DoctorDto
{
    public string PersonalNumber { get; set; }
    public string Password { get; set; }
    public virtual Person Person { get; set; }
    public string Specification { get; set; }
    public virtual Ambulance Ambulance { get; set; }

    public DoctorDto(string personalNumber, string password, Person person, string specification, Ambulance ambulance)
    {
        PersonalNumber = personalNumber;
        Password = password;
        Person = person;
        Specification = specification;
        Ambulance = ambulance;
    }

    public DoctorDto()
    {
    }
}
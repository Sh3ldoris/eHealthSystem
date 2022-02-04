namespace eMedicalRecordsApp.Model.TransferObjects;

public record DoctorDto
{
    public string PersonalNumber { get; set; }
    public Person Person { get; set; }
    public string Specification { get; set; }
    public Ambulance Ambulance { get; set; }

    public DoctorDto(string personalNumber, Person person, string specification, Ambulance ambulance)
    {
        PersonalNumber = personalNumber;
        Person = person;
        Specification = specification;
        Ambulance = ambulance;
    }
}
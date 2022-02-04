namespace eMedicalRecordsApp.Model;

public class PatientFilter
{
    public string Address { get; set; }
    public string BirthNumber { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public PatientFilter(string address, string birthNumber, string name, string lastName)
    {
        Address = address;
        BirthNumber = birthNumber;
        Name = name;
        LastName = lastName;
    }

    public PatientFilter()
    {
        Address = "";
        BirthNumber = "";
        Name = "";
        LastName = "";
    }
}
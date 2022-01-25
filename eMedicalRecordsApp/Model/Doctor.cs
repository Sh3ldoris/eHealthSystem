namespace eMedicalRecordsApp.Model;

public class Doctor
{
    public string PersonalNumber { get; set; }
    public string Password { get; set; }
    public Person Person { get; set; }
    public string specification { get; set; }
    public Ambulance Ambulance { get; set; }
}
namespace eMedicalRecordsApp.Model.TransferObjects;

public record PatientDto
{
    public string Code { get; set; }
    public string Insurance { get; set; }
    public Person Person { get; set; }
    public UrgentInfo? UrgentInfo { get; set; }
    public Anamnesis? Anamnesis { get; set; }
    public DoctorDto? Doctor { get; set; }
    public List<string> CanAccess { get; set; }

    public PatientDto(string code, string insurance, Person person, UrgentInfo? urgentInfo, Anamnesis? anamnesis, DoctorDto? doctor, List<string> canAccess)
    {
        Code = code;
        Insurance = insurance;
        Person = person;
        UrgentInfo = urgentInfo;
        Anamnesis = anamnesis;
        Doctor = doctor;
        CanAccess = canAccess;
    }

    public PatientDto()
    {
    }
}
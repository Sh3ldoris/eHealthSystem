namespace eMedicalRecordsApp.Model.TransferObjects;

public record PatientDto(string Code, string Insurance, Person Person, UrgentInfo? UrgentInfo, Anamnesis? Anamnesis, DoctorDto? Doctor, List<string>? CanAccess)
{
    public string Code { get; set; } = Code;
    public string Insurance { get; set; } = Insurance;
    public Person Person { get; set; } = Person;
    public UrgentInfo? UrgentInfo { get; set; } = UrgentInfo;
    public Anamnesis? Anamnesis { get; set; } = Anamnesis;
    public DoctorDto? Doctor { get; set; } = Doctor;
    public List<string>? CanAccess { get; set; } = CanAccess;
}
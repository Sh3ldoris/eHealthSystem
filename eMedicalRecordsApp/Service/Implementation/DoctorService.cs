using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;

namespace eMedicalRecordsApp.Service.Implementation;

public class DoctorService : IDoctorService
{
    private readonly SystemContext _systemContext;

    public DoctorService()
    {
        _systemContext = new SystemContext();
    }
    
    public Doctor Get(string personalNumber)
    {
        return _systemContext.Doctors.FirstOrDefault(d => personalNumber.Equals(d.PersonalNumber))!;
    }
}
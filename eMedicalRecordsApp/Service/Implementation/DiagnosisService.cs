using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;

namespace eMedicalRecordsApp.Service.Implementation;

public class DiagnosisService : IDiagnosisService
{
    private readonly SystemContext _systemContext;

    public DiagnosisService()
    {
        _systemContext = new SystemContext();
    }
    
    public IEnumerable<Diagnosis> GetAll()
    {
        return _systemContext.Diagnosis;
    }
}
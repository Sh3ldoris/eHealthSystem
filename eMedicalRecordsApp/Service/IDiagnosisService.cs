using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IDiagnosisService
{
    public IEnumerable<Diagnosis> GetAll();
}
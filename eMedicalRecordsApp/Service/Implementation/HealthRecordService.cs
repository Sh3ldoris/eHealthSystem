using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;

namespace eMedicalRecordsApp.Service.Implementation;

public class HealthRecordService : IHealthRecordService
{
    private readonly SystemContext _systemContext;

    public HealthRecordService()
    {
        _systemContext = new SystemContext();
    }

    public IEnumerable<HealthRecord> GetAllByPatientCode(string code)
    {
        var patient = _systemContext.Patients.FirstOrDefault(p => code.Equals(p.Code));
        if (patient == null)
        {
            //TODO: Log that cannot find patient by given code
            return Enumerable.Empty<HealthRecord>();
        }
        
        return _systemContext.HealthRecords
            .Where(record => patient.Code.Equals(record.Patient.Code));
    }

    public HealthRecord Save(HealthRecord record)
    {
        throw new NotImplementedException();
    }
}
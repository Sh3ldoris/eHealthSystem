using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IHealthRecordService
{
    IEnumerable<HealthRecord> GetAllByPatientCode(string code);
    HealthRecord Save(HealthRecord record);
}
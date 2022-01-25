using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface HealthRecordService
{
    IEnumerable<HealthRecord> GetAllByPatientCode(string code);
    HealthRecord Save(HealthRecord record);
}
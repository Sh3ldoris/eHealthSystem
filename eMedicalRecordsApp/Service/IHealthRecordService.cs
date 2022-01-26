using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IHealthRecordService
{
    IEnumerable<HealthRecord> GetAllByPatient(Patient patient);
    HealthRecord Save(HealthRecord record);
}
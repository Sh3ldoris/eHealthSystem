using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp.Service;

public interface IHealthRecordService
{
    IEnumerable<HealthRecord> GetAllByPatientCode(string code);
    HealthRecord Save(HealthRecordDto record);
}
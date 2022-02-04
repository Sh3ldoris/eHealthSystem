using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp.Service.Implementation;

public class HealthRecordService : IHealthRecordService
{
    private readonly ILogger _logger;
    private readonly SystemContext _systemContext;

    public HealthRecordService(ILogger<HealthRecordService> logger)
    {
        _logger = logger;
        _systemContext = new SystemContext();
    }

    public IEnumerable<HealthRecord> GetAllByPatientCode(string code)
    {
        var patient = _systemContext.Patients.FirstOrDefault(p => code.Equals(p.Code));
        if (patient == null)
        {
            _logger.LogWarning($"Cannot find patient by given code -> {code}");
            return Enumerable.Empty<HealthRecord>();
        }
        
        return _systemContext.HealthRecords
            .Where(record => patient.Code.Equals(record.Patient.Code));
    }

    public HealthRecord Save(HealthRecordDto record)
    {
        var doctor = _systemContext.Doctors.FirstOrDefault(d => record.Doctor.PersonalNumber.Equals(d.PersonalNumber));
        var patient = _systemContext.Patients.FirstOrDefault(p => record.PatientCode.Equals(p.Code));
        var newAd = new List<AssignedDiagnosis>();

        if (record.Diagnosis != null)
        {
            record.Diagnosis.ForEach(ad =>
            {
                ad.Diagnosis = _systemContext.Diagnosis.FirstOrDefault(d => ad.Diagnosis.Code.Equals(d.Code))!;
            });
            newAd = record.Diagnosis
                .Select(ad =>
                    new AssignedDiagnosis(
                        ad.Localization, 
                        ad.Diagnosis
                        )
                )
                .ToList();
            
            var nullDiagnosis = record.Diagnosis.FindAll(ad => ad.Diagnosis == null).ToList().Count;
            
            if (nullDiagnosis > 0)
            {
                _logger.LogWarning("Cannot find diagnosis");
                return null!;
            }
        }
        if (patient == null || doctor == null)
        {
            _logger.LogWarning("Cannot find patient or doctor");
            return null!;
        }

        var newRecord = new HealthRecord(
            Guid.NewGuid().ToString(),
            record.Date,
            record.Title,
            doctor,
            patient,
            record.Report,
            newAd
            );

        _systemContext.HealthRecords.Add(newRecord);
        _systemContext.SaveChanges();
        
        return newRecord;
    }
}
using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;
using eMedicalRecordsApp.Model.TransferObjects;

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
                //TODO: Log that cannot find one of the properties
                return null!;
            }
        }
        if (patient == null || doctor == null)
        {
            //TODO: Log that cannot find one of the properties
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
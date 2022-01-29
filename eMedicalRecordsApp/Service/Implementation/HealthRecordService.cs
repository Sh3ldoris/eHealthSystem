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
        record.Diagnosis.ForEach(ad =>
        {
            ad.Diagnosis = _systemContext.Diagnosis.FirstOrDefault(d => ad.Diagnosis.Code.Equals(d.Code));
        });

        var nullDiagnosis = record.Diagnosis.FindAll(ad => ad.Diagnosis == null).ToList().Count;

        if (patient == null || doctor == null || nullDiagnosis > 0)
        {
            //TODO: Log that cannot find one of the properties
            return null!;
        }

        var newAd = record.Diagnosis
            .Select(ad =>
                new AssignedDiagnosis()
                    {
                        Diagnosis = ad.Diagnosis,
                        Localization = ad.Localization
                    })
            .ToList();

        var newRecord = new HealthRecord
        {
            Date = record.Date,
            Title = record.Title,
            Report = record.Report,
            Diagnosis = newAd,
            Doctor = doctor,
            Patient = patient,
            Id = Guid.NewGuid().ToString()
        };

        _systemContext.HealthRecords.Add(newRecord);
        _systemContext.SaveChanges();
        
        return newRecord;
    }
}
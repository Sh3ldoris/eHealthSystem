using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp;

public static class MappingUtils
{
    public static List<PatientDto> MapPatientsToListDto(IEnumerable<Patient> patients)
    {
        return patients
            .Select(MapPatientToDto)
            .ToList();
    }

    public static PatientDto MapPatientToDto(Patient patient)
    {
        return new PatientDto()
        {
            Code = patient.Code,
            Insurance = patient.Insurance,
            Person = patient.Person,
            UrgentInfo = patient.UrgentInfo,
            Doctor = patient.Doctor != null ? MapDoctorToDto(patient.Doctor) : null,
            CanAccess = patient.CanAccess.Select(d => d.PersonalNumber).ToList()
        };
    }

    public static DoctorDto MapDoctorToDto(Doctor doctor)
    {
        return new DoctorDto()
        {
            PersonalNumber = doctor.PersonalNumber,
            Password = doctor.Password,
            Person = doctor.Person,
            Specification = doctor.Specification,
            Ambulance = doctor.Ambulance
        };
    }

    public static List<HealthRecordDto> MapRecordsToListDto(IEnumerable<HealthRecord> records)
    {
        return records
            .Select(MapRecordToDto)
            .ToList();
    }

    public static HealthRecordDto MapRecordToDto(HealthRecord record)
    {
        return new HealthRecordDto()
        {
            Date = record.Date,
            Diagnosis = record.Diagnosis != null ? MapAssignedDiagnosesToListDto(record.Diagnosis) : null,
            Doctor = MapDoctorToDto(record.Doctor),
            PatientCode = record.Patient.Code,
            Report = record.Report,
            Title = record.Title
        };
    }
    
    public static List<AssignedDiagnosisDto> MapAssignedDiagnosesToListDto(IEnumerable<AssignedDiagnosis> diagnoses)
    {
        return diagnoses
            .Select(MapAssignedDiagnosisToDto)
            .ToList();
    }

    public static AssignedDiagnosisDto MapAssignedDiagnosisToDto(AssignedDiagnosis diagnosis)
    {
        return new AssignedDiagnosisDto()
        {
            Diagnosis = diagnosis.Diagnosis,
            Localization = diagnosis.Localization
        };
    }
}
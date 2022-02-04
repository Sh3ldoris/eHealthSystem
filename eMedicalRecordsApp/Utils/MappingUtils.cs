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
        return new PatientDto(
            patient.Code, 
            patient.Insurance, 
            patient.Person, 
            patient.UrgentInfo, 
            patient.Anamnesis,
            patient.Doctor != null ? MapDoctorToDto(patient.Doctor) : null,
            patient.CanAccess?.Select(d => d.PersonalNumber).ToList()
            );
    }

    public static DoctorDto MapDoctorToDto(Doctor doctor)
    {
        return new DoctorDto(
            doctor.PersonalNumber,
            doctor.Person,
            doctor.Specification,
            doctor.Ambulance
        );
    }

    public static List<HealthRecordDto> MapRecordsToListDto(IEnumerable<HealthRecord> records)
    {
        return records
            .Select(MapRecordToDto)
            .ToList();
    }

    public static HealthRecordDto MapRecordToDto(HealthRecord record)
    {
        return new HealthRecordDto(
                record.Date,
                record.Title,
                MapDoctorToDto(record.Doctor),
                record.Patient.Code,
                record.Report,
                record.Diagnosis != null ? MapAssignedDiagnosesToListDto(record.Diagnosis) : null
        );
    }
    
    public static List<AssignedDiagnosisDto> MapAssignedDiagnosesToListDto(IEnumerable<AssignedDiagnosis> diagnoses)
    {
        return diagnoses
            .Select(MapAssignedDiagnosisToDto)
            .ToList();
    }

    public static AssignedDiagnosisDto MapAssignedDiagnosisToDto(AssignedDiagnosis diagnosis)
    {
        return new AssignedDiagnosisDto(
                diagnosis.Localization,
                diagnosis.Diagnosis
            );
    }

    public static UserDto MapUserToDto(User user)
    {
        return new UserDto(user.Code, MapDoctorToDto(user.UserDoctor));
    }
}
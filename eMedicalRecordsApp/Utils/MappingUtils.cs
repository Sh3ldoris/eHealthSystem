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
            Doctor = MapDoctorToDto(patient.Doctor),
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
}
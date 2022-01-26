using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IPatientService
{
    IEnumerable<Patient> GetAllWithUrgentInfo();
    Patient GetWithAnamesis(string patientCode);
    IEnumerable<Patient> GetAllWithUrgentInfoByDoctor(Doctor doctor);
    IEnumerable<Patient> GetAllWithUrgentInfoByFilter(PatientFilter filter);
    Patient AddNew(Patient patient);
    Patient UpdateExisting(Patient patient);
}
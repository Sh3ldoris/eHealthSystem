using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp.Service;

public interface IPatientService
{
    IEnumerable<Patient> GetAll();
    Patient Get(string patientCode);
    IEnumerable<Patient> GetAllWithUrgentInfoByDoctor(Doctor doctor);
    IEnumerable<Patient> GetAllWithUrgentInfoByFilter(PatientFilter filter);
    Patient AddNew(PatientDto patient);
    Patient UpdateExisting(Patient patient);
}
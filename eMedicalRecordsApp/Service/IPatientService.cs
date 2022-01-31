using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp.Service;

public interface IPatientService
{
    IEnumerable<Patient> GetAll();
    Patient Get(string patientCode);
    IEnumerable<Patient> GetAllByDoctor(string doctorNumber);
    IEnumerable<Patient> GetAllFilter(PatientFilter filter);
    Patient AddNew(PatientDto patient);
    Patient UpdateExisting(PatientDto patient);
}
using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface PatientService
{
    IEnumerable<Patient> GetAll();
    Patient GetByCode(string code);
    Patient GetByDoctor(Doctor doctor);
    IEnumerable<Patient> GetByFilter(PatientFilter filter);
    Patient Save(Patient patient);
    Patient Update(Patient patient);
}
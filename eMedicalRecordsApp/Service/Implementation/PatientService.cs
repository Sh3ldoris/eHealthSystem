using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;
using eMedicalRecordsApp.Model.TransferObjects;

namespace eMedicalRecordsApp.Service.Implementation;

public class PatientService : IPatientService
{
    private readonly SystemContext _systemContext;

    public PatientService()
    {
        _systemContext = new SystemContext();
    }

    public IEnumerable<Patient> GetAll()
    {
        return _systemContext.Patients;
    }

    public Patient Get(string patientCode)
    {
        return _systemContext.Patients.FirstOrDefault(p => patientCode.Equals(p.Code));
    }

    public IEnumerable<Patient> GetAllWithUrgentInfoByDoctor(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Patient> GetAllWithUrgentInfoByFilter(PatientFilter filter)
    {
        throw new NotImplementedException();
    }

    public Patient AddNew(PatientDto patient)
    {
            var newPatient = new Patient();
            var canAccessDoctors = _systemContext.Doctors
                .Where(doctor => patient.CanAccess.Contains(doctor.PersonalNumber))
                .ToList();
            
            newPatient.CanAccess = canAccessDoctors;
            newPatient.Code = patient.Code;
            newPatient.Insurance = patient.Insurance;
            newPatient.Person = patient.Person;
            newPatient.UrgentInfo = patient.UrgentInfo;
            newPatient.Doctor = patient.Doctor;
            if (patient.Anamnesis == null)
            {
                newPatient.Anamnesis = CreateBlankAnamnesis();
            }
            else
            {
                newPatient.Anamnesis = patient.Anamnesis;
            }

            _systemContext.Patients.Add(newPatient);
            _systemContext.SaveChanges();
            return newPatient;
    }

    public Patient UpdateExisting(Patient patient)
    {
        throw new NotImplementedException();
    }

    private Anamnesis CreateBlankAnamnesis()
    {
        return new Anamnesis()
        {
            CurrentDiseases = "",
            Abuses = "",
            FamilyAnamnesis = "",
            GynecologicalHistory = "",
            PharmacologyHistory = "",
            PhysiologicalFunctions = "",
            PreviousPeriod = ""
        };
    }
}
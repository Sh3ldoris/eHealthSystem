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
        return _systemContext.Patients.FirstOrDefault(p => patientCode.Equals(p.Code))!;
    }

    public IEnumerable<Patient> GetAllByDoctor(string doctorNumber)
    {
        var doctor = _systemContext.Doctors
            .FirstOrDefault(d => doctorNumber.Equals(d.PersonalNumber));
        if (doctor == null)
        {
            //TODO: Log that cannot find doctor by given personal number
            return Enumerable.Empty<Patient>();
        }

        return _systemContext.Patients
            .Where(p =>
                p.CanAccess.FirstOrDefault(d => doctor.PersonalNumber.Equals(d.PersonalNumber)) != null
            );
    }

    public IEnumerable<Patient> GetAllFilter(PatientFilter filter)
    {
        return _systemContext.Patients
            .Where(p =>
                p.Person.BirthNumber.ToLower().Contains(filter.BirthNumber.ToLower()) &&
                p.Person.FirstName.ToLower().Contains(filter.Name.ToLower()) &&
                p.Person.LastName.ToLower().Contains(filter.LastName.ToLower()) &&
                p.Person.Address.ToLower().Contains(filter.Address.ToLower())
            );
    }

    public Patient AddNew(PatientDto patient)
    {
        var patientDoctor = patient.Doctor != null ?
                _systemContext.Doctors.FirstOrDefault(d => patient.Doctor.PersonalNumber.Equals(d.PersonalNumber)) 
                : null;
            var canAccessDoctors = _systemContext.Doctors
                .Where(doctor => patient.CanAccess != null && patient.CanAccess.Contains(doctor.PersonalNumber))
                .ToList();
            
            var newPatient = new Patient(
                    patient.Code,
                    patient.Insurance,
                    patient.Person,
                    patient.UrgentInfo,
                    patient.Anamnesis ?? CreateBlankAnamnesis(),
                    patientDoctor,
                    canAccessDoctors
                );

            _systemContext.Patients.Add(newPatient);
            _systemContext.SaveChanges();
            return newPatient;
    }

    public Patient UpdateExisting(PatientDto patient)
    {
        var patientDoctor = patient.Doctor != null ?
            _systemContext.Doctors.FirstOrDefault(d => patient.Doctor.PersonalNumber.Equals(d.PersonalNumber)) 
            : null;
        var canAccessDoctors = _systemContext.Doctors
            .Where(doctor => patient.CanAccess != null && patient.CanAccess.Contains(doctor.PersonalNumber))
            .ToList();
        var patientPerson =
            _systemContext.Persons.FirstOrDefault(p => patient.Person.BirthNumber.Equals(p.BirthNumber));
        var updatingPatient = _systemContext.Patients.FirstOrDefault(p => patient.Code.Equals(p.Code));

        if (updatingPatient == null || patientPerson == null)
        {
            //TODO: Cannot find patient to update
            return null!;
        }
        
        //Can update person too (Some fields only)!
        patientPerson.Occupation = patient.Person.Occupation;
        patientPerson.FamilyState = patient.Person.FamilyState;

        updatingPatient.Code = patient.Code;
        updatingPatient.Insurance = patient.Insurance;
        updatingPatient.Person = patientPerson;
        updatingPatient.UrgentInfo = patient.UrgentInfo;
        updatingPatient.Anamnesis = patient.Anamnesis;
        updatingPatient.Doctor = patientDoctor;
        updatingPatient.CanAccess = canAccessDoctors;

        _systemContext.SaveChanges();
        return updatingPatient;
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
using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]   
    public IActionResult AllPatients()
    {
        var patients = _patientService.GetAll();
        var result = patients.Select(patient => new PatientDto()
            {
                Code = patient.Code,
                Insurance = patient.Insurance,
                Person = patient.Person,
                UrgentInfo = patient.UrgentInfo,
                Doctor = patient.Doctor,
                CanAccess = patient.CanAccess.Select(d => d.PersonalNumber).ToList()
            })
            .ToList();
        return Ok(result);
    }

    [HttpGet("{code}")]
    public IActionResult PatientByCode(string code)
    {
        var patient = _patientService.Get(code);
        if (patient != null)
        {
            return Ok(new PatientDto()
            {
                Code = patient.Code,
                Insurance = patient.Insurance,
                Person = patient.Person,
                UrgentInfo = patient.UrgentInfo,
                Doctor = patient.Doctor,
                Anamnesis = patient.Anamnesis,
                CanAccess = patient.CanAccess.Select(d => d.PersonalNumber).ToList()
            });   
        }

        return NotFound();
    }

    [HttpPost("doctor")]
    public IActionResult PatientByDoctor(Doctor doctor)
    {
        return Ok(Enumerable.Empty<Patient>());
    }
    
    [HttpGet("filtered")]
    public IActionResult PatientByFilter(PatientFilter filter)
    {
        return Ok(Enumerable.Empty<Patient>());
    }

    [HttpPost]
    public IActionResult SavePatient(PatientDto patient)
    {
        var newPatient = _patientService.AddNew(patient);
        return Accepted(newPatient);
    }
    
    [HttpPut]
    public IActionResult UpdatePatient(Patient patient)
    {
        return Accepted();
    }
}
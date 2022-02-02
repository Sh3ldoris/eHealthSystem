using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    
    [HttpGet]   
    public IActionResult AllPatients()
    {
        var result = _patientService.GetAll();
        return Ok(MappingUtils.MapPatientsToListDto(result));
    }

    [HttpGet("{code}")]
    public IActionResult PatientByCode(string code)
    {
        var patient = _patientService.Get(code);
        if (patient != null)
        {
            return Ok(MappingUtils.MapPatientToDto(patient));   
        }

        return NotFound();
    }

    [HttpGet("doctor/{personalNumber}")]
    public IActionResult PatientByDoctor(string personalNumber)
    {
        var result = _patientService.GetAllByDoctor(personalNumber);
        return Ok(MappingUtils.MapPatientsToListDto(result));
    }
    
    [HttpPost("filtered")]
    public IActionResult PatientByFilter(PatientFilter filter)
    {
        var result = _patientService.GetAllFilter(filter);
        return Ok(MappingUtils.MapPatientsToListDto(result));
    }

    [HttpPost]
    public IActionResult SavePatient(PatientDto patient)
    {
        var newPatient = _patientService.AddNew(patient);
        return Accepted(MappingUtils.MapPatientToDto(newPatient));
    }
    
    [HttpPut]
    public IActionResult UpdatePatient(PatientDto patient)
    {
        var updatedPatient = _patientService.UpdateExisting(patient);
        return Accepted(MappingUtils.MapPatientToDto(updatedPatient));
    }
}
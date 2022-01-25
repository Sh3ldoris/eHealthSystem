using eMedicalRecordsApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    
    [HttpGet]   
    public IActionResult AllPatients()
    {
        return Ok(Enumerable.Empty<Patient>());
    }

    [HttpGet("{code}")]
    public IActionResult PatientByCode(string code)
    {
        return Ok();
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
    public IActionResult SavePatient(Patient patient)
    {
        return Accepted();
    }
    
    [HttpPut]
    public IActionResult UpdatePatient(Patient patient)
    {
        return Accepted();
    }
}
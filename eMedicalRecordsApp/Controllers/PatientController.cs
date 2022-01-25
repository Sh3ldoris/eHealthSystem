using eMedicalRecordsApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    
    [HttpGet]   
    public IActionResult GetAllPatients()
    {
        return Ok(Enumerable.Empty<Patient>());
    }

    [HttpGet("{code}")]
    public IActionResult GetPatientByCode(string code)
    {
        return Ok(Enumerable.Empty<Patient>());
    }
}
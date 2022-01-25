using eMedicalRecordsApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("records")]
public class HealthRecordController : ControllerBase
{
    [HttpGet("{code}")]   
    public IActionResult RecordsByPatientCode(string code)
    {
        return Ok(Enumerable.Empty<HealthRecord>());
    }

    [HttpPost]
    public IActionResult SaveNewRecord(HealthRecord record)
    {
        return Accepted();
    }
}
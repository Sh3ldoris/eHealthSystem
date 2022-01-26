using eMedicalRecordsApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("diagnosis")]
public class DiagnosisController : ControllerBase
{

    public IActionResult GetAllDiagnosis()
    {
        return Ok(Enumerable.Empty<Diagnosis>());
    }
}
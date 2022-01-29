using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Service;
using eMedicalRecordsApp.Service.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("diagnosis")]
public class DiagnosisController : ControllerBase
{
    private IDiagnosisService _diagnosisService;

    public DiagnosisController(IDiagnosisService diagnosisService)
    {
        _diagnosisService = diagnosisService;
    }

    [HttpGet]
    public IActionResult GetAllDiagnosis()
    {
        return Ok(_diagnosisService.GetAll());
    }
}
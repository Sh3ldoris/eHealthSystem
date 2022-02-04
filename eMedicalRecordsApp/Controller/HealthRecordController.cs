using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Security;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[CustomAuth]
[ApiController]
[Route("records")]
public class HealthRecordController : ControllerBase
{
    private IHealthRecordService _healthRecordService;
    public HealthRecordController(IHealthRecordService healthRecordService)
    {
        _healthRecordService = healthRecordService;
    }
    
    [HttpGet("{code}")]
    public IActionResult RecordsByPatientCode(string code)
    {
        var result = _healthRecordService.GetAllByPatientCode(code);
        return Ok(MappingUtils.MapRecordsToListDto(result));
    }

    [HttpPost]
    public IActionResult SaveNewRecord(HealthRecordDto record)
    {
        var result = _healthRecordService.Save(record);
        if (result == null)
        {
            return NotFound();
        }
        return Accepted(MappingUtils.MapRecordToDto(result));
    }
}
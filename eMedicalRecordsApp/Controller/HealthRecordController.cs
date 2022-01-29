using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

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
        var result = _healthRecordService.GetAllByPatientCode(code)
            .Select(record => new HealthRecordDto()
            {
                Date = record.Date,
                Title = record.Title,
                Doctor = record.Doctor,
                Report = record.Report,
                diagnosis = record.diagnosis,
                PatientCode = record.Patient.Code
            })
            .ToList();
        
        return Ok(result);
    }

    [HttpPost]
    public IActionResult SaveNewRecord(HealthRecord record)
    {
        return Accepted();
    }
}
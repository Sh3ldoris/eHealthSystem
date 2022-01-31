using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("doctors")]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("{personalNumber}")]
    public IActionResult DoctorByPersonalNumber(string personalNumber)
    {
        var doctor = _doctorService.Get(personalNumber);
        if (doctor != null)
        {
            return Ok(MappingUtils.MapDoctorToDto(doctor));   
        }

        return NotFound();
    }
}
using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("db/init")]
public class DbInitController : ControllerBase
{
    [HttpGet]   
    public IActionResult CreateDatabase()
    {
        using (var ctx = new SystemContext())
        {
            ctx.Database.EnsureCreated();
        }
        return Ok();
    }
    
    [HttpGet("doctor")]   
    public IActionResult AddDoctors()
    {
        using (var ctx = new SystemContext())
        {
            var person1 = new Person()
            {
                FirstName = "MUDr. Vladimír",
                LastName = "Kusko",
                Gender = "",
                BirthNumber = "doctor/1",
                Address = "",
                Phone = "",
                FamilyState = "",
                Occupation = ""
            };
            
            var person2 = new Person()
            {
                FirstName = "MUDr. Elena",
                LastName = "Auxtova",
                Gender = "",
                BirthNumber = "doctor/2",
                Address = "",
                Phone = "",
                FamilyState = "",
                Occupation = ""
            };
            
            var doctor1 = new Doctor()
            {
                PersonalNumber = "5ZY0123",
                Password = "admin123",
                Person = person1,
                Specification = "oftalmológ",
                Ambulance = new Ambulance()
                {
                    Id = 1,
                    Address = "ul. V. Spanyola 43, Žilina 010 01",
                    Name = "O Č N Á   A M B U L A N C I A"
                }
            };
            
            var doctor2 = new Doctor()
            {
                PersonalNumber = "5ZY0153",
                Password = "lekar",
                Person = person2,
                Specification = "všeobecná starostlivosť o deti a dorast",
                Ambulance = new Ambulance()
                {
                    Id = 2,
                    Address = "Štúrova  481/5 97646  Valaská",
                    Name = "Všeobecná ambulancia pre deti a dorast, Valaská"
                }
            };

            List<Doctor> doctors = new List<Doctor>() {doctor1, doctor2};
            ctx.Doctors.AddRange(doctors);
            ctx.SaveChanges();
        }
        return Ok();
    }

    [HttpPost("diagnoses")]
    public IActionResult InitDiagnosis(List<Diagnosis> diagnoses)
    {
        using (var ctx = new SystemContext())
        {
            ctx.Diagnosis.AddRange(diagnoses);
            ctx.SaveChanges();
        }
        return Ok();
    }
}
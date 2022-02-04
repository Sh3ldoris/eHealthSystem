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
            var person1 = new Person(
                "doctor/1",
                "MUDr. Vladimír",
                "Kucko",
                "MALE",
                new DateTime(1998, 10, 10),
                "Predajna",
                "112",
                "Slovbodny",
                "Pracant"
                );
            
            var person2 = new Person(
                "doctor/2",
                "MUDr. Elena",
                "Auxtova",
                "FEMALE",
                new DateTime(1998, 10, 10),
                "Predajna",
                "112",
                "Slovbodny",
                "Pracant"
            );

            var doctor1 = new Doctor(
                "5ZY0123",
                person1,
                "oftalmológ",
                new Ambulance("O Č N Á   A M B U L A N C I A", "ul. V. Spanyola 43, Žilina 010 01"),
                null,
                null
                );

            var doctor2 = new Doctor(
                "5ZY0153",
                person2,
                "všeobecná starostlivosť o deti a dorast",
                new Ambulance("Štúrova  481/5 97646  Valaská", "Všeobecná ambulancia pre deti a dorast, Valaská"),
                null,
                null
            );

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

    [HttpGet("user")] 
    public IActionResult InitUsers()
    {
        using (var ctx = new SystemContext())
        {
            var data = ctx.Doctors.Select(d => new User("Pass123", d));
            ctx.Users.AddRange(data);
            ctx.SaveChanges();
        }
        
        return Ok();
    }
}
using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Security;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtSettings _jwtSettings;

    public AuthController(IUserService userService, IOptions<JwtSettings> jwtSettings)
    {
        _userService = userService;
        _jwtSettings = jwtSettings.Value;
    }
    
    [HttpPost]
    public IActionResult LogIn(LoginRequest login)
    {
        var user = _userService.Get(login.PersonalNumber);

        if (user == null || !user.Password.Equals(login.Password))
        {
            return BadRequest(new { message = "Incorrect login" });
        }

        var token = JwtUtils.GenerateJwtToken(user, _jwtSettings.Secret);
        return Ok(new { Token = token, Message = "Success" });
    }
    
}
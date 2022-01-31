using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult LogIn(LoginRequest login)
    {
        var user = _userService.Get(login.PersonalNumber);
        if (user.Password.Equals(login.Password))
        {
            return Accepted(MappingUtils.MapUserToDto(user));
        }
        return Unauthorized();
    }
}
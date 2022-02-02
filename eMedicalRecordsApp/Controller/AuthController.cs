using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eMedicalRecordsApp.Model.TransferObjects;
using eMedicalRecordsApp.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eMedicalRecordsApp.Controller;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    /*private IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    */
    
    [HttpPost]
    public IActionResult LogIn(LoginRequest login)
    {
        IdentityUser identityUser;

        if (!ModelState.IsValid)
        {
            return new BadRequestObjectResult(new { Message = "Login failed" });
        }

        var token = GenerateToken(login.PersonalNumber);
        return Ok(new { Token = token, Message = "Success" });
    }
    
    private object GenerateToken(string name)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication"));

        var signingCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, name)
            }),

            Expires = DateTime.UtcNow.AddSeconds(10000),
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
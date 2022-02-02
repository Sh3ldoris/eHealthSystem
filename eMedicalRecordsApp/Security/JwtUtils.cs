using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eMedicalRecordsApp.Model;
using Microsoft.IdentityModel.Tokens;

namespace eMedicalRecordsApp.Security;

public static class JwtUtils
{
    public static string GenerateJwtToken(User user, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.Code.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
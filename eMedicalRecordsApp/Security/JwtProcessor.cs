using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace eMedicalRecordsApp.Security;

public class JwtProcessor
{
    private readonly RequestDelegate _next;
    private readonly JwtSettings _jwtSettings;

    public JwtProcessor(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
    {
        _next = next;
        _jwtSettings = jwtSettings.Value;
    }
    
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null || ValidateToken(token) == null)
        {
            context.Items["Authorized"] = false;
        }
        else
        {
            context.Items["Authorized"] = true;
        }
        
        await _next(context);
    }

    private JwtSecurityToken ValidateToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            
            return (JwtSecurityToken)validatedToken;
        }
        catch
        {
            //In a case of error while validating (Unsuccessful validation)
            return null!;
        }
    }
}
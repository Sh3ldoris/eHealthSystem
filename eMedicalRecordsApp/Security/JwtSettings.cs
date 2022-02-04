namespace eMedicalRecordsApp.Security;

public class JwtSettings
{
    public string Secret { get; set; }

    public JwtSettings(string secret)
    {
        Secret = secret;
    }

    public JwtSettings()
    {
        Secret = "";
    }
}
using eMedicalRecordsApp.Model;
using eMedicalRecordsApp.Model.DBContext;

namespace eMedicalRecordsApp.Service.Implementation;

public class UserService : IUserService
{
    private readonly SystemContext _systemContext;

    public UserService()
    {
        _systemContext = new SystemContext();
    }
    
    public User Get(string doctorPersonalNumber)
    {
        return _systemContext.Users.FirstOrDefault(p => doctorPersonalNumber.Equals(p.Code))!;
    }
}
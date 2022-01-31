using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IUserService
{
    public User Get(string doctorPersonalNumber);
}
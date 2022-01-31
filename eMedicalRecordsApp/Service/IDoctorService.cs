using eMedicalRecordsApp.Model;

namespace eMedicalRecordsApp.Service;

public interface IDoctorService
{
    public Doctor Get(string personalNumber);
}
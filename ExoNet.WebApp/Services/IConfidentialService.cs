namespace ExoNet.WebApp.Services
{
    public interface IConfidentialService
    {
        bool Authenticate(string email);
    }
}

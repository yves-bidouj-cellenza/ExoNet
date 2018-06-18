namespace ExoNet.WebApp.Services
{
    public interface IAuthenticationService
    {
        bool Authenticate(string email, string password);
    }
}

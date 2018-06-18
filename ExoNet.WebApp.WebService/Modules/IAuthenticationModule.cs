namespace ExoNet.WebApp.WebService.Modules
{
    public interface IAuthenticationModule
    {
        bool Authenticate(string email, string password);
    }
}

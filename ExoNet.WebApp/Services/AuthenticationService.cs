using ExoNet.WebApp.Helpers;
using System.Net;

namespace ExoNet.WebApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string BaseAddress = @"http://localhost:53350/";
        private readonly string AuthenticateUri = @"api/authenticate/";

        public bool Authenticate(string email, string password)
        {
            var query = $"{AuthenticateUri}{WebUtility.UrlEncode(email)}/{WebUtility.UrlEncode(password)}";
            return WebHelper.Post<bool>(BaseAddress, query);
        }
    }
}

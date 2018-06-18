using System.Collections.Generic;

namespace ExoNet.WebApp.WebService.Modules
{
    public class AuthenticationModule : IAuthenticationModule
    {
        private readonly IDictionary<string, string> _repository;

        public bool Authenticate(string email, string password)
        {
            if(_repository.TryGetValue(email, out var expected))
            {
                return password == expected;
            }

            return false;
        }

        public AuthenticationModule()
        {
            _repository = new Dictionary<string, string>
            {
                { "test@test.com","test" }
            };
        }
    }
}

using ExoNet.WebApp.WebService.Modules;
using Microsoft.AspNetCore.Mvc;

namespace ExoNet.WebApp.WebService.Controllers
{
    [Route("api/authenticate")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationModule _module;

        public AuthenticationController(IAuthenticationModule module)
        {
            _module = module;
        }

        [HttpPost("{email}/{password}")]
        [Produces("application/json")]
        public bool Authenticate(string email, string password)
        {
            return _module.Authenticate(email, password);
        }
    }
}
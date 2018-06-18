using ExoNet.WebApp.SecuredWebService.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoNet.WebApp.SecuredWebService.Controllers
{
    [Route("api/confidentials")]
    public class ConfidentialController : Controller
    {
        private readonly IConfidentialModule _module;
        private const string AuthenticateUri = @"api/confidentials";

        public ConfidentialController(IConfidentialModule module)
        {
            _module = module;
        }

        [HttpGet("{email}")]
        [Produces("application/json")]
        public bool Authenticate(string email)
        {
            if (!VerifySignature(HttpContext))
            {
                return false;
            }
            return _module.Authenticate(email);
        }


        private bool VerifySignature(HttpContext context)
        {
            var typed = context.Request.GetTypedHeaders();
            string value = typed.Headers["Authorization"];

            if(string.IsNullOrEmpty(value))
            {
                return false;
            }
            var values = value.Split(":");

            var keyId = values[0]?.Replace("Authorization ", "");
            var signature = values[1];
            var date = typed.Date.Value.UtcDateTime;

            return _module.IsValidSignature(keyId, signature, date, AuthenticateUri);
        }
    }
}

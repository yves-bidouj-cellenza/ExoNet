using ExoNet.WebApp.Security;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ExoNet.WebApp.SecuredWebService
{
    public class SecurityMiddleWare
    {
        private readonly RequestDelegate _next;
        private const string AuthenticateUri = @"api/confidentials";

        public SecurityMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var typed = context.Request.GetTypedHeaders();
            string value = context.Request.Headers["Authorization"];
            var values = value.Split(":");

            var date = typed.Date.Value.UtcDateTime;

            var keyId = values[0].Replace("Authorization ", "");
            var signature = values[1];

            var message = Secret.BuildMessage(date, AuthenticateUri);
            var computeSignature = Hmacsha1.ComputeSignature(Secret.GetSecretKey(keyId), message);

            var result = signature.Equals(computeSignature);
            if (!result)
            {
                context.Abort();
            }
            await _next?.Invoke(context);
        }
    }
}

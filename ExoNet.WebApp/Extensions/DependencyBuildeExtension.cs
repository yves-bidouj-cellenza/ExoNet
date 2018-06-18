using ExoNet.WebApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExoNet.WebApp.Extensions
{
    public static class DependencyBuildeExtension
    {
        public static void BuidDependencies(this IServiceCollection service)
        {
            service.AddTransient<IAuthenticationService, AuthenticationService>();
            service.AddTransient<IConfidentialService, ConfidentialService>();
        }
    }
}

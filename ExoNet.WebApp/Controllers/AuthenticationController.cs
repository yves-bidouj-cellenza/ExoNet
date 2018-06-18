using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExoNet.WebApp.Models;
using ExoNet.WebApp.Services;

namespace ExoNet.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfidentialService _confidentialAuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IConfidentialService confidentialAuthenticationService)
        {
            _authenticationService = authenticationService;
            _confidentialAuthenticationService = confidentialAuthenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate(AuthenticationViewModel authentication)
        {
            var isAuthenticate = CallAuthenticate(authentication);
            var message = $"Connnection {(isAuthenticate ? "Succeed" : "Failed")}";
            SetMessage(message);
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool CallAuthenticate(AuthenticationViewModel authentication)
        {
            if(authentication.IsConfidential)
            {
                return _confidentialAuthenticationService.Authenticate(authentication.Email);
            }
            else
            {
                return _authenticationService.Authenticate(authentication.Email, authentication.Password);
            }
        }

        private void SetMessage(string message)
        {
            ViewData["Message"] = message;
        }
    }
}

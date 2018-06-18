using System;

namespace ExoNet.WebApp.SecuredWebService.Modules
{
    public interface IConfidentialModule
    {
        bool Authenticate(string email);

        bool IsValidSignature(string accessKey, string signature, DateTime date, string path);
    }
}

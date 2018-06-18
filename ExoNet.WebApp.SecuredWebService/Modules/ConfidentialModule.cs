using ExoNet.WebApp.Security;
using System;
using System.Collections.Generic;

namespace ExoNet.WebApp.SecuredWebService.Modules
{
    public class ConfidentialModule : IConfidentialModule
    {
        private readonly List<string> _repository;

        public ConfidentialModule()
        {
        _repository = new List<string>
            {
                "test@test.com"
            };

        }

        public bool Authenticate(string email)
        {
            return _repository.Contains(email);
        }

        public bool IsValidSignature(string accessKey, string signature, DateTime date, string path)
        {
            var message = Secret.BuildMessage(date, path);
            var computeSignature = Hmacsha1.ComputeSignature(Secret.GetSecretKey(accessKey), message);

            return signature.Equals(computeSignature);
        }
    }
}

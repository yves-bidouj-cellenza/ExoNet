using ExoNet.WebApp.Helpers;
using ExoNet.WebApp.Security;
using ExoNet.WebApp.Security.HttpClientExtensions;
using System;
using System.Net;
using System.Net.Http;

namespace ExoNet.WebApp.Services
{
    public class ConfidentialService : IConfidentialService
    {
        private const string BaseAddress = @"http://localhost:57510/";
        private const string AuthenticateUri = @"api/confidentials";
        public bool Authenticate(string email)
        {
            var query = $"{AuthenticateUri}/{WebUtility.UrlEncode(email)}";
            using (var client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
                var date = DateTime.UtcNow;
                var message = Secret.BuildMessage(date, AuthenticateUri);
                var signature = Hmacsha1.ComputeSignature(Secret.GetSecretKey(Secret.AccessKeyId), message);
                client.AddHeader(Secret.AccessKeyId, signature, date);
                var response = client.GetAsync(query).Result;
                return WebHelper.Deserialize<bool>(response);
            }
        }
    }
}
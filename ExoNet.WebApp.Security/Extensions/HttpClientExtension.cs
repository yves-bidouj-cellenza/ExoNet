using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExoNet.WebApp.Security.HttpClientExtensions
{
    public static class HttpClientExtension
    {
        public static void AddHeader(this HttpClient client, string key, string signature, DateTime date)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", $"{key}:{signature}");
            client.DefaultRequestHeaders.Date = new DateTimeOffset(date);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ExoNet.WebApp.Helpers
{
    public static class WebHelper
    {
        public static T Post<T>(string baseAddress, string query)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(baseAddress) })
            {
                var response = client.PostAsync(query, null).Result;
                return Deserialize<T>(response);
            }
        }

        public static T Deserialize<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
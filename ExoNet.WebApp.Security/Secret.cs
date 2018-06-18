using System;
using System.Collections.Generic;

namespace ExoNet.WebApp.Security
{
    public static class Secret
    {
        public const string AccessKeyId = "31177037";

        private static IDictionary<string, string> _vault;

        static Secret()
        {
            _vault = new Dictionary<string, string> { { AccessKeyId, "3B78D037DB414A3FB569611776BC84BE" } };
        }

        public static string GetSecretKey(string accessId)
        {
            return _vault.TryGetValue(accessId, out var value) ? value : string.Empty;
        }

        public static string BuildMessage(DateTime date, string resource)
        {
            return $"GET{date}{resource}";
        }
    }
}

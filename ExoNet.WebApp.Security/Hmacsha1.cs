using System;
using System.Security.Cryptography;
using System.Text;

namespace ExoNet.WebApp.Security
{
    public static class Hmacsha1
    {
        public static string ComputeSignature(string key, string input)
        {
            Encoding encoding = new UTF8Encoding();
            return ComputeSignature(encoding.GetBytes(key), encoding.GetBytes(input));
        }

        private static string ComputeSignature(byte[] key, byte[] input)
        {
            using (var hmac = new HMACSHA1(key))
            {
                var hash = hmac.ComputeHash(input);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
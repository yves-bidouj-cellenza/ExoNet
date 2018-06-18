using System;
using System.Security.Cryptography;
using System.Text;

namespace ExoNet.WebApp.SecuredWebService.Helpers
{
    public static class Hmacsha1Helper
    {
        public static string ComputeSignature(string secretKey, string input)
        {
            var enc = Encoding.ASCII;
            using (var hmac = new HMACSHA1(enc.GetBytes(secretKey)))
            {   
                var buffer = enc.GetBytes(input);
                var result = BitConverter.ToString(hmac.ComputeHash(buffer));
                return result.Replace("-", "").ToLower();
            }
        }

        public static bool Verify(string secretKey, string input)
        {
            // Initialize the keyed hash object. 
            var enc = Encoding.ASCII;
            using (var hmac = new HMACSHA1(enc.GetBytes(secretKey)))
            {
                // Create an array to hold the keyed hash value read from the file.
                byte[] storedHash = new byte[hmac.HashSize / 8];
                // Create a FileStream for the source file.
                // Compute the hash of the remaining contents of the file.
                // The stream is properly positioned at the beginning of the content, 
                // immediately after the stored hash value.
                byte[] computedHash = hmac.ComputeHash(enc.GetBytes(input));
                // compare the computed hash with the stored value

                for (int i = 0; i < storedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
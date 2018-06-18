using System;
using Xunit;

namespace ExoNet.WebApp.Security.Test
{
    public class Hmacsha1Test
    {
        [Fact]
        public void SignAndCompareWithSameData()
        {
            var ressource = "/test";
            var secretKey = Secret.GetSecretKey(Secret.AccessKeyId);
            var date = DateTime.UtcNow;
            var message = Secret.BuildMessage(date, ressource);
            var signature = Hmacsha1.ComputeSignature(secretKey, message);
            var signature2 = Hmacsha1.ComputeSignature(secretKey, message);
            Assert.True(signature == signature2);
        }

        [Fact]
        public void SignAndCompareWithDifferentDate()
        {
            var ressource = "/test";
            var secretKey = Secret.GetSecretKey(Secret.AccessKeyId);
            var firsDate = DateTime.UtcNow;
            var secondDate = firsDate.AddSeconds(1);
            var firstMessage = Secret.BuildMessage(firsDate, ressource);
            var secondMessage = Secret.BuildMessage(secondDate, ressource);
            var signature = Hmacsha1.ComputeSignature(secretKey, firstMessage);
            var signature2 = Hmacsha1.ComputeSignature(secretKey, secondMessage);
            Assert.True(signature != signature2);
        }
    }
}

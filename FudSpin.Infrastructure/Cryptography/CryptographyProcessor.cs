using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FudSpin.Infrastructure.Cryptography
{
    public class CryptographyProcessor : ICryptographyProcessor
    {
        private readonly IConfiguration configuration;
        public CryptographyProcessor(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateHash(string input)
        {
            string salt = CreateSalt(int.Parse(configuration.GetSection("SaltKey").Value));

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using SHA256Managed sHA256ManagedString = new();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool AreEqual(string plainTextInput, string hashedInput)
        {
            string newHashedPin = GenerateHash(plainTextInput);
            return newHashedPin.Equals(hashedInput);
        }

        public string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            using RNGCryptoServiceProvider rng = new();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
    }
}

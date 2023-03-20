using Microsoft.Extensions.Options;
using soan_backend.Helpers.HashingHelper;
using soan_backend.Services.Interfaces;
using System;
using System.Security.Cryptography;

namespace soan_backend.Services.HashingService
{
    public class PasswordHashingService : IPasswordHashing
    {
        private readonly Encrypt _options;
        public PasswordHashingService(IOptions<Encrypt> options)
        {
            _options = options.Value;
        }
        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');

            if(parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format");
            }

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);


            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA512))
            {
                var keyToCheck = algorithm.GetBytes(_options.KeySize);
                return keyToCheck.SequenceEqual(key); 
               
            };


        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, _options.SaltSize, _options.Iterations, HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_options.Iterations}.{salt}.{key}";

            };
        }
    }
}

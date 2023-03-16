using Microsoft.EntityFrameworkCore;
using soan_backend.Domain;
using System.Security.Cryptography;

namespace soan_backend.Data
{
    public static class ModelBuilderExtensions
    {
     
        public static void Seed(this ModelBuilder builder)
        {

            builder.Entity<User>().HasData(
                new User { Id = 1, Name = "AdminSoan", Password_Bash = PasswordEncrypt("Admin2445"), Email = "soanadmin@gmail.com" }
                
            );

        }


        public static string PasswordEncrypt(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, 16 , 10000, HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(32));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{10000}.{salt}.{key}";

            };
        }
    }
}

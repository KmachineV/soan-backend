using System.Security.Cryptography;

namespace soan_backend.Helpers.HashingHelper
{
    public class Encrypt    
    {
        
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}

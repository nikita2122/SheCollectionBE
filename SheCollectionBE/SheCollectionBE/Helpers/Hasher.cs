
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace SheCollectionBE.Helpers
{
    public class Hasher
    {
        public static string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                password: password!,
                                salt: Encoding.ASCII.GetBytes("salt"),
                                prf: KeyDerivationPrf.HMACSHA256,
                                iterationCount: 100000,
                                numBytesRequested: 256 / 8));
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace Users.API.Model
{
    public static class Crypto
    {   
        public static string GenerateHash(this string value) {
            var hash = SHA1.Create();
            var array = Encoding.ASCII.GetBytes(value);

            array = hash.ComputeHash(array);
            var stringHex = new StringBuilder();

            foreach(var item in array) {
                stringHex.Append(item.ToString("x2"));
            }

            return stringHex.ToString();
        }
    }
}
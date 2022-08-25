using System.Security.Cryptography;
using System.Text;

namespace EmreUgur.BackedProject.Common.Helpers
{
    public class PasswordHelper
    {
        public static string PasswordEnCrypt(string password)
        {
            SHA256Managed sHA256 = new SHA256Managed();

            byte[] arrayPassword = ConvertByte(password);

            byte[] arrayHashPassword = sHA256.ComputeHash(arrayPassword);

            return BitConverter.ToString(arrayHashPassword);
        }
        private static byte[] ConvertByte(string password)
        {
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

            return unicodeEncoding.GetBytes(password);
        }
    }
}

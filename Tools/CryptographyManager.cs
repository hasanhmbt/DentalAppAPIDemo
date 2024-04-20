using System.Security.Cryptography;
using System.Text;

namespace DentalAppAPIDemo.Tools
{
    public class CryptographyManager
    {
        public static string GetSHA256(string value)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.Unicode.GetBytes(value);
                byte[] hash = sha256.ComputeHash(bytes);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }


        public static string GetMD5(string value)
        {


            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(value))
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(value);
                    byte[] hash = md5.ComputeHash(bytes);

                    foreach (byte b in hash)
                    {
                        sb.Append(b.ToString("X2"));
                    }

                }
            }
            return sb.ToString();



        }




    }
}

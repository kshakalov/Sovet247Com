using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Sovet247Admin.Models
{
    public class ConsultationsPasswordHasher:IPasswordHasher
    {

        public string HashPassword(string password)
        {
            var md5 = MD5.Create();
            byte[] data=md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb=new StringBuilder();
            for (var i=0;i<data.Length;i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(providedPassword));
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            if(hashedPassword==sb.ToString())
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}
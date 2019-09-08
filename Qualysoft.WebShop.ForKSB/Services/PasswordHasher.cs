using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly string hashCode = "jjqual"; // Ubacite ovde string za password hashovanje (sta god)
        private byte[] utf;
        private byte[] keys = new byte[256];
        private byte[] hashed;

        public string EncryptPass(string pass)
        {
            utf = UTF8Encoding.UTF8.GetBytes(pass);
            using (MD5CryptoServiceProvider crypt = new MD5CryptoServiceProvider())
            {
                keys = crypt.ComputeHash(UTF8Encoding.UTF8.GetBytes(hashCode));
                using (TripleDESCryptoServiceProvider tcrypt = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transformer = tcrypt.CreateEncryptor();
                    hashed = transformer.TransformFinalBlock(utf, 0, utf.Length);

                    return Convert.ToBase64String(hashed, 0, hashed.Length);
                }

            }
        }
    }
}

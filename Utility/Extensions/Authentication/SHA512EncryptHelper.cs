using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Utility.Extensions.Authentication
{
    public class SHA512EncryptHelper : IEncryptHelper
    {
        public string Encrypt(string key, string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return source;
            }

            var encoding = Encoding.UTF8;
            byte[] keyByte = encoding.GetBytes(key);
            byte[] sourceByte = encoding.GetBytes(source);

            using (HMACSHA256 sha512 = new HMACSHA256(keyByte))
            {
                var encryptContentByte = sha512.ComputeHash(sourceByte);

                StringBuilder encryptContent = new StringBuilder();
                foreach (byte item in encryptContentByte)
                {
                    encryptContent.Append(item.ToString("x2")); // hex format
                }

                return encryptContent.ToString();
            }            
        }
    }
}

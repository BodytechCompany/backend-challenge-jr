using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Bodytech.Application.Helper.Cypher
{
    public static class Cypher
    {
        private static string CypherKey = ConfigurationManager.AppSettings["cypher.key"];
        private static string CypherSalt = ConfigurationManager.AppSettings["cypher.salt"];

        public static string Encrypt(string value)
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(CypherKey, Encoding.Unicode.GetBytes(CypherSalt));

            if (value == null || value.Length <= 0)
                throw new ArgumentNullException("plainText");

            byte[] encrypted;
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = rgb.GetBytes(rijAlg.KeySize >> 3);
                rijAlg.IV = rgb.GetBytes(rijAlg.BlockSize >> 3);

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(value);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted.ToArray());

        }

        public static string Decrypt(string encrypted)
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(CypherKey, Encoding.Unicode.GetBytes(CypherSalt));

            if (encrypted == null || encrypted.Length <= 0)
                throw new ArgumentNullException();

            string plaintext = null;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = rgb.GetBytes(rijAlg.KeySize >> 3);
                rijAlg.IV = rgb.GetBytes(rijAlg.BlockSize >> 3);

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encrypted)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }
}
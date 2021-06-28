using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shorter.Core
{
    public class ECBTranslator : Translator<string, EncryptedString>
    {
        static readonly byte[] bytes = Encoding.UTF8.GetBytes("vndWasdk"); 
        
        public override EncryptedString Translate(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            var cryptoProvider = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB
            };

            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            var writer = new StreamWriter(cryptoStream);
            writer.Write(value);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return new EncryptedString(Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
        }

        public override string Translate(EncryptedString value)
        {
            var cryptedString = value.Value;
            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }

            var cryptoProvider = new DESCryptoServiceProvider
            {
                Mode = CipherMode.ECB
            };

            var memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            var cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}

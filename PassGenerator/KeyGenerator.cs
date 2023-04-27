using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;

namespace KeyGeneratorApp
{
    public class KeyGenerator
    {
        private string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";

        public KeyGenerator(string key = "")
        {
            if(!string.IsNullOrEmpty(key))
            {
                encryptionKey = key;
            }
        }

        public string EncryptCode(string code)
        {
            string encryptedCode = "";

                        byte[] iv = new byte[16];  
            byte[] array;  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);  
                aes.IV = iv;  
  
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream())  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                    {  
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                        {  
                            streamWriter.Write(code);  
                        }  
  
                        array = memoryStream.ToArray();  
                    }  
                }  
            }  
  
            encryptedCode = "Kma%57" + Convert.ToBase64String(array) + "Krid$31";

            return encryptedCode;
        }

        public string DecryptCode(string encryptedCode)
        {
            encryptedCode = encryptedCode.Replace("Kma%57","");
            encryptedCode = encryptedCode.Replace("Krid$31","");

            string decryptedCode = "";

                        byte[] iv = new byte[16];  
            byte[] buffer = Convert.FromBase64String(encryptedCode);  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(encryptionKey);  
                aes.IV = iv;  
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream(buffer))  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))  
                    {  
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))  
                        {  
                            decryptedCode = streamReader.ReadToEnd();  
                        }  
                    }  
                }  
            }

            return decryptedCode;
        }
    }
}
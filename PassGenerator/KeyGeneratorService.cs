using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;

namespace KeyGeneratorApp
{
    public class KeyGeneratorService
    {
        private string encryptionKey = "b14ca5898a4e4133bbce2ea2315a1916";

        private string EncryptOutputFolderPath { get; set; } = @"C:\Users\komak\Documents\PasswordGenerator\EncryptedFiles";
        private string DecryptOutputFolderPath { get; set; } = @"C:\Users\komak\Documents\PasswordGenerator\DecryptedFiles";

        private KeyGenerator _keyGenerator;

        public KeyGeneratorService(string key = "")
        {
            if(!string.IsNullOrEmpty(key))
            {
                encryptionKey = key;
            }
            _keyGenerator = new KeyGenerator(encryptionKey);
        }
        
        public string EncryptCode(string code)
        {
            return _keyGenerator.EncryptCode(code);
        }

        public string DecryptCode(string encryptedCode)
        {
            return _keyGenerator.DecryptCode(encryptedCode);
        }

        public void EncryptFile(string fullFileName)
        {
            if(File.Exists(fullFileName))
            {
                var fileName = Path.GetFileName(fullFileName);
                var passwordFile = new PasswordFile(fileName,fullFileName);
                
                var originalCsvFile = CsvFileParser.ReadFile(fullFileName);

                passwordFile.Header = string.Join(";",originalCsvFile.Header);

                foreach(var element in originalCsvFile.Elements)
                {
                    var passwordEntry = new PasswordEntry(element[0],element[1],element[2],element[3],element[4]);

                    passwordEntry.Password = EncryptCode(passwordEntry.Password);

                    passwordFile.Elements.Add(passwordEntry);
                }

                passwordFile.OutputFile(EncryptOutputFolderPath);
            }
            else
            {
                Console.WriteLine($"Error => Unable to find {fullFileName} file.");
            }
        }

        public void DecryptFile(string fullFileName)
        {
            if(File.Exists(fullFileName))
            {
                var fileName = Path.GetFileName(fullFileName);
                var passwordFile = new PasswordFile(fileName,fullFileName);

                var originalCsvFile = CsvFileParser.ReadFile(fullFileName);

                passwordFile.Header = string.Join(";",originalCsvFile.Header);

                foreach(var element in originalCsvFile.Elements)
                {
                    var passwordEntry = new PasswordEntry(element[0],element[1],element[2],element[3],element[4]);

                    passwordEntry.Password = DecryptCode(passwordEntry.Password);

                    passwordFile.Elements.Add(passwordEntry);
                }

                passwordFile.OutputFile(DecryptOutputFolderPath);
            }
            else
            {
                Console.WriteLine($"Error => Unable to find {fullFileName} file.");
            }
        }
    }
}
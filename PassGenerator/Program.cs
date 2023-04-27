namespace KeyGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                Console.WriteLine("Please press Enter to continue ...");
                Console.ReadKey();
            
                var encryptionMode = args[0];
                                
                var keyGeneratorService = new KeyGeneratorService();

                switch(encryptionMode)
                {
                    case "ENCRYPT":
                        Console.WriteLine("\n\n-----------------------------------------------");
                        Console.WriteLine("Application Mode: ENCRYPTION");
                        
                        var code = args[1];
                        var encryptedCode = keyGeneratorService.EncryptCode(code);

                        if(!string.IsNullOrEmpty(code))
                        {
                            Console.WriteLine(string.Format("Source Password: {0}",code));
                            Console.WriteLine(string.Format("Ecrypted Password: {0}",encryptedCode));
                        }
                        else
                        {
                            Console.WriteLine("Error => Unable to encrypt password: " + code);
                        }
                        
                        Console.WriteLine("\n\n-----------------------------------------------\n\n");
                        break;
                    case "DECRYPT":
                        
                        Console.WriteLine("\n\n-----------------------------------------------");
                        Console.WriteLine("Application Mode: DECRYPTION");
                        
                        var encryptedPassword = args[1];
                        var decryptedCode = keyGeneratorService.DecryptCode(encryptedPassword);

                        if(!string.IsNullOrEmpty(decryptedCode))
                        {
                            Console.WriteLine(string.Format("Encrypted Password: {0}",encryptedPassword));
                            Console.WriteLine(string.Format("Decrypted Password: {0}",decryptedCode));
                        }
                        else
                        {
                            Console.WriteLine("Error => Unable to decrypt password: " + encryptedPassword);
                        }
                        
                        Console.WriteLine("\n\n-----------------------------------------------\n\n");

                        break;
                    case "ENCRYPT_FILE":

                        Console.WriteLine("Application Mode: ENCRYP FILE");
                        
                        var fullFileName = args[1];

                        if(!string.IsNullOrEmpty(fullFileName))
                        {
                            keyGeneratorService.EncryptFile(fullFileName);
                        }
                        else
                        {
                            Console.WriteLine("Error => Unable to encrypt file: " + fullFileName);
                        }

                        break;
                    case "DECRYPT_FILE":
                        
                        Console.WriteLine("Application Mode: DECRYPT FILE");
                        
                        var fullEncryptedFileName = args[1];

                        if(!string.IsNullOrEmpty(fullEncryptedFileName))
                        {
                            keyGeneratorService.DecryptFile(fullEncryptedFileName);
                        }
                        else
                        {
                            Console.WriteLine("Error => Unable to decrypt file: " + fullEncryptedFileName);
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Error => Please retry by providing a valid application Mode (e.g. ENCRYPT, DECRYPT)");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error => Please retry by providing valid arguments to proceed.");
            } 

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}

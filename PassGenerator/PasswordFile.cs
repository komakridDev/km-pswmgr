namespace KeyGeneratorApp
{
    public class PasswordFile
    {
        public string FileName { get; set; }

        public string FullFileName { get; set; }

        public string Header { get; set; }

        public List<PasswordEntry> Elements { get; set; } = new List<PasswordEntry>();

        public PasswordFile(string fileName, string fullFileName)
        {
            FileName = fileName;
            FullFileName = fullFileName;
            Header = "";
            Elements = new List<PasswordEntry>();
        }

        public void OutputFile(string outputFolder)
        {
            Console.WriteLine($"File name: {FileName}");
            Console.WriteLine($"Full path: {FullFileName}");

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputFolder, $"{(DateTime.Now.ToString("yyyyMMdd"))}_{(DateTime.Now.ToString("HHmmss"))}_{FileName}")))
            {
                outputFile.WriteLine(Header);
                foreach (var element in Elements)
                    outputFile.WriteLine(element.ToString());
            }
        }

        public void DumbFile()
        {
            Console.WriteLine($"File name: {FileName}");
            Console.WriteLine($"Full path: {FullFileName}");

            Console.WriteLine(Header);

            foreach(var element in Elements)
            {
                Console.WriteLine(element.ToString());
            }
        }
    }

    public class PasswordEntry
    {
        public string Account { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public string Website { get; set; }

        public string Comments { get; set; }

        public PasswordEntry (string account, string loginName, string password, string website, string comments)
        {
            Account = account;
            LoginName = loginName;
            Password = password;
            Website = website;
            Comments = comments;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4}",Account,LoginName,Password,Website,Comments);
        }
    }
}
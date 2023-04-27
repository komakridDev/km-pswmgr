namespace KeyGeneratorApp
{
    public class CsvFile
    {
        
        public string FileName { get; set; }

        public List<string> Header { get; set; }

        public List<List<string>> Elements { get; set; }

        public CsvFile(string fileName)
        {
            FileName = fileName;
            Header = new List<string>();
            Elements = new List<List<string>>();
        }

        public CsvFile(string fileName, List<string> header, List<List<string>> elements)
        {
            FileName = fileName;
            Header = header;
            Elements = elements;
        }
    }
}
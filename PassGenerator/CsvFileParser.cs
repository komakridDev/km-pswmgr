using System.IO;

namespace KeyGeneratorApp
{
    public static class CsvFileParser
    {
        public static CsvFile ReadFile(string fileNameFullPath)
        {
            CsvFile csvFile = new CsvFile(Path.GetFileName(fileNameFullPath));    

            using(var reader = new StreamReader(fileNameFullPath))
            {                 
                int lineIndex = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if(lineIndex == 0)
                    {
                        if(!string.IsNullOrEmpty(line))
                        {
                            var values = line.Split(';');

                            csvFile.Header = values.ToList();   
                        }
                        else
                        {
                            Console.WriteLine("Error => Invalid File Content. Unable to read Header Line of csv.");
                        }  
                    }
                    else
                    {
                        if(!string.IsNullOrEmpty(line))
                        {
                            var values = line.Split(';');

                            csvFile.Elements.Add(values.ToList());  
                        }            
                    }
                    lineIndex++;                                    
                }
            }

            return csvFile;
        }
    }
}
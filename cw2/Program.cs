using System;
using System.IO;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ErrorLogger();

            var sourcePath = @"data.csv";
            var resultPath = @"result.xml";
            var resultType = "xml";

            try
            {
                sourcePath = args[0];
                resultPath = args[1];
                resultType = args[2];
            }
            catch (Exception)
            {
                log.Add(new ArgumentException("Missing argumets, defult values will be used."));
            }

            if (File.Exists(sourcePath))
            {
                log.Add($"Source: '{sourcePath}'.");
                log.Add($"Result: '{resultPath}'.");
                log.Add($"Data type: '{resultType}'.");                


            }
            else
            {
                log.Add(new FileNotFoundException($"'{sourcePath}' does not exist, nothing to do."));
            }

            log.Stop();
        }
    }
}

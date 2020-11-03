using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cw2
{
    class ErrorLogger
    {
        string path = @"log.txt";
        Writer writer;

        public ErrorLogger()
        {
            writer = new Writer(path, false);
        }

        ErrorLogger(string path) : base()
        {
            this.path = path;
        }

        public void Add(Exception ex)
        {
            writer.WriteLine($"{DateTime.Now}: {ex};");
        }
    }
}

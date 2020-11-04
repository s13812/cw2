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
            Start();
        }

        ErrorLogger(string path) : base()
        {
            this.path = path;
        }

        public void Add(Exception exception)
        {
            Write($"ERROR:\t{exception}");
        }

        public void Add(String log)
        {
            Write($"LOG:\t\t{log}");
        }

        void Start()
        {
            Add("Program started.");
        }

        void Write(string message)
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }

        public void Stop()
        {
            Add("Program stopped.\n--------------------\n");
        }
    }
}

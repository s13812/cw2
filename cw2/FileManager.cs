using System.IO;

namespace cw2
{
    class FileManager
    {
        public string path;

        public FileManager(string path)
        {
            this.path = path;
        }
    }
    class Reader : FileManager
    {
        public Reader(string path) : base(path)
        {
        }
    }

    class Writer : FileManager
    {
        readonly bool overwriteMode = true;

        //public Writer(string path) : base(path)
        //{
        //}

        public Writer(string path, bool overwriteMode = true) : base(path)
        {
            this.overwriteMode = overwriteMode;
        }

        internal void WriteLine(string s)
        {
            StreamWriter sw;
            if (overwriteMode)
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = File.AppendText(path);
            }

            sw.WriteLine(s);
            sw.Dispose();
        }
    }
}

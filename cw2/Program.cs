using System;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new ErrorLogger();

            try
            {
                var i = args[0];
            }
            catch (Exception ex)
            {
                log.Add(ex);
            }

            Console.WriteLine("End!");
        }
    }
}

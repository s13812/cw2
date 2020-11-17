using System;
using System.Collections.Generic;
using System.IO;
using cw2.models;

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
                log.Add(new ArgumentException("Missing argumets, default values will be used."));
            }

            if (File.Exists(sourcePath))
            {
                log.Add($"Source: '{sourcePath}'.");
                log.Add($"Result: '{resultPath}'.");
                log.Add($"Data type: '{resultType}'.");

                //List<Student> students = new List<Student>();
                Dictionary<string, Student> students = new Dictionary<string, Student>();

                using (var stream = new StreamReader(sourcePath))
                {
                    string line = null;
                    int lineNo = 1;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');
                        var st = new Student
                        {
                            indexNumber = student[4],
                            fname = student[0],
                            lname = student[1],
                            birthdate = student[5],
                            email = student[6],
                            mothersName = student[7],
                            fathersName = student[8],
                            studies = new Study
                            {
                                name = student[2],
                                mode = student[3]
                            }
                        };
                        if (st.IsValid())
                        {
                            try
                            {
                                students.Add(st.GetKey(), st);
                            }
                            catch (ArgumentException ex)
                            {

                            }
                        }
                        else
                        {
                            log.Add(new Exception($"'{st}' is invalid (line {lineNo} of '{sourcePath}'); skipping."));
                        }
                        lineNo++;
                    }
                }

                foreach (Student s in students.Values)
                {
                    Console.WriteLine(s);
                }

            }
            else
            {
                log.Add(new FileNotFoundException($"'{sourcePath}' does not exist, nothing to do."));
            }

            log.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;
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

                Dictionary<string, Student> students = new Dictionary<string, Student>();
                Dictionary<string, int> studies = new Dictionary<string, int>();

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
                                var study = st.studies.name;
                                if (studies.ContainsKey(study))
                                {
                                    studies[study]++;
                                }
                                else
                                {
                                    studies.Add(study, 1);
                                }
                            }
                            catch (ArgumentException)
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

                Uczelnia uczelnia = new Uczelnia
                {
                    createdAt = DateTime.Today.ToShortDateString(),
                    author = "Michal Razowski",
                    studenci = students.Values.ToList(),
                    activeStudies = new List<ActiveStudy>()
                };

                foreach (var s in studies)
                {
                    uczelnia.activeStudies.Add(new ActiveStudy
                    {
                        name = s.Key,
                        numberOfStudents = s.Value
                    });
                }

                if (resultType.ToLower().Equals("xml"))
                {
                    FileStream writer = new FileStream(resultPath, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia), new XmlRootAttribute("uczelnia"));
                    serializer.Serialize(writer, uczelnia);
                } 
                else if (resultType.ToLower().Equals("json"))
                {
                    var jsonString = JsonSerializer.Serialize(uczelnia);
                    File.WriteAllText(resultPath, jsonString);
                }
                else
                {
                    log.Add(new ArgumentException($"'{resultType}' is not a correct output type."));
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    public class Student
    {
        [XmlAttribute]
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public List<Study> studies { get; set; }
    }
}

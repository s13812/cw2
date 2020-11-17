using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    public class ActiveStudy
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string numberOfStudents { get; set; }
    }
}

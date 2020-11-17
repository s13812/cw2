using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    public class Uczelnia
    {
        [XmlAttribute]
        public string createdAt { get; set; }
        [XmlAttribute]
        public string author { get; set; }
        public List<Student> studenci { get; set; }
        public List<ActiveStudy> activeStudies { get; set; }
    }
}

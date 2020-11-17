using System;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    [XmlType(TypeName = "studies")]
    public class ActiveStudy
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public int numberOfStudents { get; set; }
    }
}

using System;
using System.Xml.Serialization;

namespace cw2.models
{
    [Serializable]
    [XmlType(TypeName = "student")]
    public class Student
    {
        [XmlAttribute]
        public string indexNumber { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }
        public Study studies { get; set; }

        override public string ToString()
        {
            return $"Student: {fname} {lname}, {indexNumber}";
        }

        public bool IsValid()
        {
            return indexNumber.Length != 0 && fname.Length != 0 && lname.Length != 0 && birthdate.Length != 0 && email.Length != 0 && mothersName.Length != 0 && fathersName.Length != 0 && studies.name.Length != 0 && studies.mode.Length != 0;
        }

        public string GetKey()
        {
            return fname + lname + indexNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
    [Serializable]
    public class Student
    {
        internal Studies studies;

        [XmlAttribute(attributeName:"studentNumber")]
        public string StudentNumber { get; set; }

        [XmlElement(elementName:"email")]
        public string Email { get; set; }

        [XmlElement(elementName:"fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName:"lname")]
        public string LastName { get; set; }

        [XmlElement(elementName:"birthDate")]
        public string BirthDate { get; set; }

        [XmlElement(elementName:"fatherName")]
        public string FatherName { get; set; }

        [XmlElement(elementName:"motherName")]
        public string MotherName { get; set; }

        [XmlElement(elementName:"studies")]
        public Studies Studies { get; set; }
    }
}

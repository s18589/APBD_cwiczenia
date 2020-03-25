using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
    [Serializable]
    public class Student
    {

        [XmlAttribute(attributeName:"studentNumber")]
        [JsonPropertyName("studentNumber")]
        public string StudentNumber { get; set; }

        [XmlElement(elementName:"email")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [XmlElement(elementName:"fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }

        [XmlElement(elementName:"lname")]
        [JsonPropertyName("lname")]
        public string LastName { get; set; }

        [XmlElement(elementName:"birthDate")]
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }

        [XmlElement(elementName:"fatherName")]
        [JsonPropertyName("fatherName")]
        public string FatherName { get; set; }

        [XmlElement(elementName:"motherName")]
        [JsonPropertyName("motherName")]
        public string MotherName { get; set; }

        [XmlElement(elementName:"studies")]
        [JsonPropertyName("studies")]
        public Studies Studies { get; set; }
    }
}

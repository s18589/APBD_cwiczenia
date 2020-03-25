using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
    [Serializable]
    public class ActiveStudies
    {
        [XmlElement(elementName: "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [XmlElement(elementName: "numberOfStudents")]
        [JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cwiczenia2.Models
{
    [Serializable]
    public class Studies
    {
        [XmlElement(elementName:"name")]
        public string Name { get; set; }

        [XmlElement(elementName:"mode")]
        public string Mode { get; set; }

        [XmlElement(elementName:"numberOfStudents")]
        public int numberOfStudents { get; set; }
    }
}

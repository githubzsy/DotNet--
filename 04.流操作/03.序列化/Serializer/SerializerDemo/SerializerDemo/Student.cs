using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerDemo
{
    public class Student
    {
        public int Id { get; set; }

        //[XmlElement("RealName")]
        // [JsonPropertyName("Windy")]
        public string Name { get; set; }

    }
}

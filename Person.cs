using System;
using System.Xml.Serialization;

namespace FileInteraction
{
    public class Person
    {
        // fields
        [XmlAttribute]
        public string? name { get; set; }
        public double? height {get; set; }
        public double? weight {get; set; }

        private XmlSerializer Serializer { get; } = new XmlSerializer(typeof(Person));

        public Person() {}

        // constructor

        public Person(string? name, double? height, double? weight)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
        }ls
        

        // methods

        public string SerializeAsXml()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }
    }
}
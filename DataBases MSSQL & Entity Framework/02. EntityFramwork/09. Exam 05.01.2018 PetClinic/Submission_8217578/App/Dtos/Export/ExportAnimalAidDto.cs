using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos.Export
{
    [XmlType("AnimalAid")]
    public class ExportAnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]   
        public decimal Price { get; set; }
    }
}

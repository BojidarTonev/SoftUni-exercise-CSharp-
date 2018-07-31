using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.Export
{
    [XmlType("user")]
    public class UsersDtoo
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlArray("sold-products")]
        public SoldProductsDto[] SoldProducts{ get; set; }
    }
}

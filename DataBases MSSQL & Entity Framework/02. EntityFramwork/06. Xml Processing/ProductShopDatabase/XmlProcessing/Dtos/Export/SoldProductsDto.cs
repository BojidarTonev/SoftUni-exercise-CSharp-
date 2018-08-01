using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.App.Dtos.Export
{
    [XmlType("sold-products")]
    public class SoldProductsDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlArray("product")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}

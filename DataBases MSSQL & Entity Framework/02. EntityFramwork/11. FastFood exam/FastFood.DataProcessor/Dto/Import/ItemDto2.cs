using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class ItemDto2
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}

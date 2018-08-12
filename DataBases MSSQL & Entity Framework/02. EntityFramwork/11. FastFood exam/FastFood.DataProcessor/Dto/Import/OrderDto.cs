using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrderDto
    {
        [XmlElement("Customer")]
        [Required]
        public string Customer { get; set; }

        [XmlElement("Employee")]
        [Required]
        public string EmployeeName { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlElement("Type")]
        [Required]
        public OrderType Type { get; set; }

        [XmlArray("Items")]
        public ItemDto2[] Items { get; set; }
    }
}

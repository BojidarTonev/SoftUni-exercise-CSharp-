using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductShop.App.Dtos.Export
{
    [XmlRoot("users")]
    public class UsersDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlArray("user")]
        public UsersDtoo[] Users { get; set; }
    }
}

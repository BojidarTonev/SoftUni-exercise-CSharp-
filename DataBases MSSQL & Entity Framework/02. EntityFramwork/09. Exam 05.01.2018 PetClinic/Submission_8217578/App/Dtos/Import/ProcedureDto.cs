using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.App.Dtos.Import
{
    [XmlType("Procedure")]
    public class ProcedureDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [XmlElement("Vet")] 
        public string VetName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{7}[0-9]{3}$")]
        [XmlElement("Animal")]
        public string AnimalSerialNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ProcedureAnimalAidDto[] AnimalAids { get; set; }
    }
}

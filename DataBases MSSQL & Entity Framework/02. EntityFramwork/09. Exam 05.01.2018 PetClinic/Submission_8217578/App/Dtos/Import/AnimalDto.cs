using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PetClinic.App.Dtos.Import
{
    public class AnimalDto
    {
        [StringLength(20, MinimumLength = 3)]
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        [JsonProperty("Type")]
        public string Type { get; set; }

        [Range(0, double.MaxValue)]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Passport")]
        public PassportDto Passport { get; set; }
    }
}

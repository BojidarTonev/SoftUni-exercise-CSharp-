using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace PetClinic.App.Dtos.Import
{
    public class AnimalAidsDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }
    }
}

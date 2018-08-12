using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ItemDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [JsonProperty("Category")]
        public string Category { get; set; }
    }
}

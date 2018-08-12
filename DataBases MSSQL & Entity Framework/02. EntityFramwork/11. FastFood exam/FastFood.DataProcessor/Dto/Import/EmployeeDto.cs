using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Import
{
    public class EmployeeDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [JsonProperty("Position")]
        public string Position { get; set; }
    }
}

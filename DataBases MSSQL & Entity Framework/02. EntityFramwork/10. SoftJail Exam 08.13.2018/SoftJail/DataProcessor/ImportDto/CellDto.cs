using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellDto
    {
        [JsonProperty("CellNumber")]
        [Required]
        [Range(1, 1001)]
        public int CellNumber { get; set; }

        [JsonProperty("HasWindow")]
        [Required]
        public bool HasWindow { get; set; }
    }
}

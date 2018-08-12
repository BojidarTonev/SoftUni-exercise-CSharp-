using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    public class MailDto
    {
        [JsonProperty("Description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty("Sender")]
        [Required]
        public string Sender { get; set; }

        [JsonProperty("Address")]
        [Required]
        [RegularExpression(@"[\w\d\s]+ str.")]
        public string Address { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerDto
    {
        [JsonProperty("FullName")]
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FullName { get; set; }

        [JsonProperty("Nickname")]
        [Required]
        [RegularExpression("The [A-Z]{1}[a-z]+")]
        public string Nickname { get; set; }

        [JsonProperty("Age")]
        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [JsonProperty("IncarcerationDate")]
        [Required]
        public string IncarcerationDate { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("Bail")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        [JsonProperty("CellId")]
        public int? CellId { get; set; }

        [JsonProperty("Mails")]
        public MailDto[] Mails { get; set; }
    }
}

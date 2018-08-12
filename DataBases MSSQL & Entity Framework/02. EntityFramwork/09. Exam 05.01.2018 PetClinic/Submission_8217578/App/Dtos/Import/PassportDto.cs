using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PetClinic.App.Dtos.Import
{
    public class PassportDto
    {
        [RegularExpression(@"^[a-zA-Z]{7}[0-9]{3}$")]
        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        [JsonProperty("OwnerName")]
        public string OwnerName { get; set; }

        [Required]
        [RegularExpression(@"(^\+359[0-9]{9}$)|(^0[0-9]{9}$)")]
        [JsonProperty("OwnerPhoneNumber")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        [JsonProperty("RegistrationDate")]
        public string RegistrationDate { get; set; }
    }
}

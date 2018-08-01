using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.App.Dtos.Import
{
    class CategoryDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

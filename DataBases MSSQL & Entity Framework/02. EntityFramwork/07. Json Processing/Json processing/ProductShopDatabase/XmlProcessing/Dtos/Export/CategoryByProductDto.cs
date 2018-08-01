using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.App.Dtos.Export
{
    class CategoryByProductDto
    {
        [JsonProperty("category")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("averagePrice")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}

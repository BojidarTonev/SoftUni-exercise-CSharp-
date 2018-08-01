using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.App.Dtos.Import
{
    class ProductDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        public int? BuyerId { get; set; }
        public User Buyer { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; }
    }
}

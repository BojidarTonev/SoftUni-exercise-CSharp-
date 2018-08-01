using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductShop.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<CategoryProducts> Products { get; set; }
    }
}

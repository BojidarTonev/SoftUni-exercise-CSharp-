using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using FastFood.Models.Enums;

namespace FastFood.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required] public OrderType Type { get; set; } = OrderType.ForHere;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [NotMapped]
        [Required]
        public decimal TotalPrice => this.OrderItems
            .Select(oi => (decimal)oi.Quantity * oi.Item.Price)
            .Sum();

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}

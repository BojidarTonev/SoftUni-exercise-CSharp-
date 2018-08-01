using System;
using System.Collections;
using System.Collections.Generic;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            this.Parts = new List<PartCars>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double TravelledDistance { get; set; }

        public ICollection<PartCars> Parts { get; set; }
    }
}

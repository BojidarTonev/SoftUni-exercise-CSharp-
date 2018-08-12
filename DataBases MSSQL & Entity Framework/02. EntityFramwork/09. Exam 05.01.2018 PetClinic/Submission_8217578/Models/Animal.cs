using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
        public Animal()
        {
            this.Procedures = new List<Procedure>();
        }

        public int Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Type { get; set; }

        [Range(0, double.MaxValue)]
        public int Age { get; set; }

        public string PassportSerialNumber { get; set; }

        [Required]
        public int PassportId { get; set; }
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}

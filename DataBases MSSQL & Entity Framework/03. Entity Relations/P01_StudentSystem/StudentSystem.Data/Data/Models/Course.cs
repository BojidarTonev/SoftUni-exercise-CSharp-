using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Homewroks = new HashSet<Homework>();
            this.Students = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> Students { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homewroks { get; set; }
    }
}

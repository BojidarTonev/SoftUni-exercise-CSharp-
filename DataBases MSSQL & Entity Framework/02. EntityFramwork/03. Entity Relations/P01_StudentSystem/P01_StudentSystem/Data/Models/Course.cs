﻿using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Homeworks = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
            this.Students = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<StudentCourse> Students { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

    }
}
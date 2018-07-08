using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        
        public DateTime? BirthDate { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }


    }
}

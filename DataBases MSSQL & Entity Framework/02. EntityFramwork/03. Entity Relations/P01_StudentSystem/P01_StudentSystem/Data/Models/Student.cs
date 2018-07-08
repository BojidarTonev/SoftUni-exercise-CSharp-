using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.Homeworks = new HashSet<Homework>();
            this.Courses = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? BirthDay { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

    }
}

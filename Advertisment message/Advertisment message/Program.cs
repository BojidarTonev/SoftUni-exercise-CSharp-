using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisment_message
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> result = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ').ToArray();
                var grades = tokens.Skip(1).Select(double.Parse).ToList();
                Student student = new Student(){Name = tokens[0], Grades = grades, AverageGrade = grades.Average()};
                result.Add(student);
            }
            foreach (var student in result.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade))
            {
                if (student.AverageGrade >= 5.00)
                {
                    Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
                }
            }
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrade { get; set; }
    }
}

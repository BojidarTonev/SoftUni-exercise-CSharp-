using System;
using System.Linq;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentInput = Console.ReadLine().Split().ToArray();
                string firstName = studentInput[0];
                string lastName = studentInput[1];
                string facultyNumber = studentInput[2];

                Student student = new Student(firstName, lastName, facultyNumber);

                var workerInput = Console.ReadLine().Split().ToArray();
                string firstNamee = workerInput[0];
                string lastNamee = workerInput[1];
                double salary = double.Parse(workerInput[2]);
                double workinghours = double.Parse(workerInput[3]);

                Worker worker = new Worker(firstNamee, lastNamee, salary, workinghours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

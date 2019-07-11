using System;

namespace IPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            IPerson citizen = new Citizen(name, age);
            Console.WriteLine(citizen);
        }
    }
}

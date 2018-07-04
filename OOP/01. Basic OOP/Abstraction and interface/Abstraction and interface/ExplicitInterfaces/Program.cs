using System;
using System.Linq;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);
                Citizen citizen = new Citizen(name, country, age);
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());           
            }         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace BirthdayCeleb
{
    class Program
    {
        static void Main(string[] args)
        {
            List <IBuyer> customers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string gangName = input[2];
                    Rebel rebel = new Rebel(name, age, gangName);
                    customers.Add(rebel);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthDate = input[3];
                    Citizen citizen = new Citizen(name, age, id , birthDate);
                    customers.Add(citizen);
                }
            }

            int result = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                foreach (var customer in customers)
                {
                    if (customer.name == input)
                    {
                        result += customer.BuyFood();
                        break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}

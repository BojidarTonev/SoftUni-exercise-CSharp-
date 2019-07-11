using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                ProcessingRawData(input, people);
            }

            ComparingData(people);
        }

        private static void ComparingData(List<Person> people)
        {
            int n = int.Parse(Console.ReadLine());
            int equalPeople = 0;
            int notEqualPeople = 0;
            Person personToCompare = people[n - 1];
            for (int i = 0; i < people.Count; i++)
            {

                if (people[i].CompareTo(personToCompare) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }

        }

        private static void ProcessingRawData(string input, List<Person> people)
        {
            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string town = tokens[2];

            Person person = new Person(name, age, town);
            people.Add(person);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            ComparingAndPrintingData(people);          
        }

        private static void ComparingAndPrintingData(List<Person>people)
        {
            var nameComparator = new ComparatorByName(people);
            var ageComparator = new ComparatorByAge(people);

            SortedSet<Person> firstSet = new SortedSet<Person>(nameComparator);
            foreach (var person in people)
            {
                firstSet.Add(person);
            }
            foreach (var person in firstSet)
            {
                Console.WriteLine(person);
            }
            SortedSet<Person> secondSet = new SortedSet<Person>(ageComparator);

            foreach (var person in people)
            {
                secondSet.Add(person);
            }
            foreach (var person in secondSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}

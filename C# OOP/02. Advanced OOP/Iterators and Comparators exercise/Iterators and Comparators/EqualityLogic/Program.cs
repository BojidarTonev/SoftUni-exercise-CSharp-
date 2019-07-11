using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    class Program
    {

        static void Main(string[] args)
        {
            //HashSorter<HashSet<Person>> hashCollector = new HashSorter<HashSet<Person>>();

            HashSet<Person> hashSet = new HashSet<Person>();
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Person person = new Person(input[0], int.Parse(input[1]));
                hashSet.Add(person);
                sortedSet.Add(person);
            }

            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);

        }
    }
}

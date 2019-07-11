using System;
using System.Linq;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            AddingItems(tokens, addCollection, addRemoveCollection, myList);
            
            int removeOperations = int.Parse(Console.ReadLine());
            RemovingItems(removeOperations, addRemoveCollection, myList);        
        }

        private static void RemovingItems(int removeOperations, AddRemoveCollection addRemoveCollection, MyList myList)
        {
            for (int i = 0; i < removeOperations; i++)
            {
                addRemoveCollection.Remove();
            }

            Console.WriteLine();

            for (int i = 0; i < removeOperations; i++)
            {
                myList.Remove();
            }

            Console.WriteLine();
        }

        private static void AddingItems(string[] tokens, AddCollection addCollection, AddRemoveCollection addRemoveCollection, MyList myList)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                addCollection.Add(tokens[i]);
            }

            Console.WriteLine();
            for (int i = 0; i < tokens.Length; i++)
            {
                addRemoveCollection.Add(tokens[i]);
            }

            Console.WriteLine();
            for (int i = 0; i < tokens.Length; i++)
            {
                myList.Add(tokens[i]);
            }

            Console.WriteLine();
        }
    }
}

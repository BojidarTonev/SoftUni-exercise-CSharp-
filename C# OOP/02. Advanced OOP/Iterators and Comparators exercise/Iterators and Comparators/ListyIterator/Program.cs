using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListIterator<string> collection;

            var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (input.Length > 1)
            {
                collection = new ListIterator<string>(input.Skip(1));
            }
            else
            {
                collection = new ListIterator<string>();
            }

            ProcessingRawData(collection);
        }

        private static void ProcessingRawData(ListIterator<string> collection)
        {
            bool finish = false;
            while (!finish)
            {
                string operation = "";

                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (input[0])
                {
                    case "Move":
                        operation = collection.Move().ToString();
                        Console.WriteLine(operation);
                        break;
                    case "HasNext":
                        operation = collection.HasNext().ToString();
                        Console.WriteLine(operation);
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    case "PrintAll":
                        collection.PrintAll();
                        break;
                    case "END":
                        finish = true;
                        break;
                }
            }
        }
    }
}

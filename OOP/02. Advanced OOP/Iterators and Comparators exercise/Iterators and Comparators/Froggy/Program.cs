using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var input = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Lake lake = new Lake(input);
            foreach (var stone in lake)
            {
                if (count == input.Length - 1)
                {
                    Console.Write($"{stone}");
                    break;
                }
                Console.Write($"{stone}, ");
                count++;
            }
            Console.WriteLine();
        }
    }
}

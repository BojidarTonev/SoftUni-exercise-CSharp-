using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_min_max_average
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<int>result = new List<int>();
            for (int i = 0; i < number; i++)
            {
                int input = int.Parse(Console.ReadLine());
                result.Add(input);
            }
            Console.WriteLine($"Sum = {result.Sum()}");
            Console.WriteLine($"Min = {result.Min()}");
            Console.WriteLine($"Max = {result.Max()}");
            Console.WriteLine($"Average = {result.Average()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double averageNumber = items.Average();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i]<averageNumber)
                {
                    items.Remove(items[i]);
                    i--;
                }
            }
            string input = Console.ReadLine();
            if (input == "Min")
            {
                Console.WriteLine(items.Min());
            }
            if (input == "Max")
            {
                Console.WriteLine(items.Max());
            }
            if (input == "All")
            {
                items = items.OrderBy(x => x).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    Console.Write(items[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

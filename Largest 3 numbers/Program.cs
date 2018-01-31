using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_3_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            List<int> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            items = items.OrderByDescending(x=>x).ToList();
            if (items.Count<3)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    result.Add(items[i]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    result.Add(items[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}

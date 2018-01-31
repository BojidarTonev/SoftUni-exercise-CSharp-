using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_decription
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int elementsToSkip = numbers[0];
            int elementsToTake = numbers[1];
            List<int> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> resultItems = items.Where(x => x >= 65 && x <= 90).ToList();
            List<int> result = resultItems.Skip(elementsToSkip).Take(elementsToTake).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write((char)result[i]);
            }
            Console.WriteLine();
        }
    }
}

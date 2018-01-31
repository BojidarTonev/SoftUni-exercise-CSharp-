using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_and_array_ext
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> removedItems = new List<int>();
            List<int> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int y;

            while (items.Count > 0)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    y = items.First();
                    items[0] = items.Last();
                    removedItems.Add(y);

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] <= y)
                        {
                            items[i] += y;
                        }
                        else
                        {
                            items[i] -= y;
                        }
                    }
                }
                else if (number >= items.Count)
                {
                    y = items.Last();
                    items[items.Count-1]= items.First();
                    removedItems.Add(y);

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] <= y)
                        {
                            items[i] += y;
                        }
                        else
                        {
                            items[i] -= y;
                        }
                    }
                }               
                else
                {
                    y = items[number];
                    removedItems.Add(y);
                    items.Remove(y);

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i] <= y)
                        {
                            items[i] += y;
                        }
                        else
                        {
                            items[i] -= y;
                        }
                    }
                }
            }
            int result = removedItems.Sum();
            Console.WriteLine(result);
        }
    }
}

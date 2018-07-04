using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowmen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int>elementsToRemove = new List<int>();
            bool finish = false;
            while (true)
            {
                if (items.Count ==1 || finish)
                {
                    break;
                }               
                for (int i = 0; i < items.Count; i++)
                {
                    int atacker = items.IndexOf(items[i]);
                    int target = items.ElementAt(atacker);
                    if (target == -1)
                    {
                        target = items[i];
                    }
                    if (target>items.Count-1)
                    {
                        target = target % items.Count;
                    }
                    int difference = Math.Abs(target - atacker);
                    if (!elementsToRemove.Contains(items.ElementAt(atacker)))
                    {
                        if (atacker == target)
                        {
                            //suicide
                            elementsToRemove.Add(items.ElementAt(atacker));
                            Console.WriteLine($"{atacker} performed harakiri");
                        }
                        else if (difference % 2 == 0)
                        {
                            //atacker wins
                            elementsToRemove.Add(items.ElementAt(target));
                            Console.WriteLine($"{atacker} x {target} -> {atacker} wins");
                        }
                        else if (difference % 2 != 0)
                        {
                            //target wins
                            elementsToRemove.Add(items.ElementAt(atacker));
                            Console.WriteLine($"{atacker} x {target} -> {target} wins");
                        }
                    }
                    if (Math.Abs(items.Count-elementsToRemove.Count)==1)
                    {
                        finish = true;
                        break;
                    }
                }
                foreach (var item in elementsToRemove)
                {
                    items.Remove(item);
                }
                elementsToRemove.Clear();
            }
        }
    }
}

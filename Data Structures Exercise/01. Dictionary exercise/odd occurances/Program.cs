using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odd_occurances
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<string> print = new List<string>();

            string[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var item in array)
            {
                string key = item.ToLower();
                if (result.ContainsKey(key))
                {
                    result[key]++;
                }
                else
                {
                    result.Add(key, 1);
                }
            }
            foreach (var key in result)
            {
                if (key.Value % 2 == 1)
                {
                    print.Add(key.Key);
                    print = print.Distinct().ToList();
                }
            }
            Console.WriteLine(string.Join(", ", print));
        }
    }
}

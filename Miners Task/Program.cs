using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miners_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            int counter = 0;
            string material = "";

            string input = Console.ReadLine();
            while (input != "stop")
            {
                if (counter % 2 == 0)
                {
                    material = input;
                    if (!result.ContainsKey(material))
                    {
                        result.Add(material, 0);
                    }
                }
                else
                {
                    int quantity = int.Parse(input);
                    result[material] += quantity;
                }
                counter++;
                input = Console.ReadLine();
            }
            foreach (var i in result)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}

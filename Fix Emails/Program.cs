using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string>result = new Dictionary<string, string>();
            int counter = 0;
            string name = "";

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "stop")
                {
                    break;
                }
                if (counter % 2 == 0)
                {
                    name = input;
                    if (!result.ContainsKey(name))
                    {
                        result.Add(name, "asd");
                    }
                }
                else
                {
                    string email = input;
                    result[name] = email;
                }
                counter++;
                input = Console.ReadLine();
            }
            foreach (var item in result)
            {
                if (!item.Value.EndsWith("us") || item.Value.EndsWith("uk"))
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}

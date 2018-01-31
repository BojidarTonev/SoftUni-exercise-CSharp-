using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hornet_Armada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string ip = tokens[0];
                string user = tokens[2];
                ip = ip.Substring(3);
                user = user.Substring(5);
                if (!result.ContainsKey(user))
                {
                    result.Add(user, new Dictionary<string, int>());
                    result[user].Add(ip, 1);
                }
                else
                {
                    if (!result[user].ContainsKey(ip))
                    {
                        result[user].Add(ip, 1);
                    }
                    else
                    {
                        result[user][ip]++;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var user in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key}: ");
                foreach (var value in user.Value)
                {
                    if (value.Key.Equals(user.Value.Keys.Last()))
                    {
                        Console.Write($"{value.Key} => {value.Value}.");
                    }
                    else
                    {
                        Console.Write($"{value.Key} => {value.Value}, ");
                    }    
                }
                Console.WriteLine();
            }        
        }
    }
}

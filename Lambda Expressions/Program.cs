using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Lambda_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "lambada")
                {
                    break;
                }
                if (input == "dance")
                {
                    foreach (var item in result)
                    {
                        string value = item.Value.First();
                        item.Value.Insert(0, value);
                    }
                }
                else
                {
                    string[] tokens = input.Split(new char[] { '=', '>', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string first = tokens.First();
                    List<string> numbers = new List<string>();
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        numbers.Add(tokens[i]);
                    }
                    if (!result.ContainsKey(tokens.First()))
                    {
                        result.Add(first, new List<string>());
                        foreach (var number in numbers)
                        {
                            result[first].Add(number);
                        }
                    }
                    else
                    {
                        result[first].Clear();
                        foreach (var item in numbers)
                        {
                            result[first].Add(item);
                        }
                    }
                    numbers.Clear();
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} => {string.Join(".", item.Value)}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace LinQuistics
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string , List<string>>();
            string input = Console.ReadLine();
            while (input != "exit")
            {
                int i = 0;
                bool isNumeric = int.TryParse(input, out i);
                if (!input.Contains('.'))
                {
                    foreach (var item in result[input].OrderByDescending(x=>x.Length).ThenByDescending(x=>x.Distinct().Count()))
                    {
                      
                                Console.WriteLine($"* {item}");
                         
                    }
                }
                if (isNumeric)
                {
                    foreach (var item in result.OrderByDescending(x=>x.Value.Max()))
                    {
                        if (i>item.Value.Count)
                        {
                            foreach (var method in item.Value.OrderBy(x=>x.Length))
                            {
                                Console.WriteLine($"* {method}");
                            }
                            break;
                        }
                        else
                        {
                            foreach (var method in item.Value.OrderBy(x=>x.Length))
                            {
                                if (i>0)
                                {
                                    Console.WriteLine($"* {method}");
                                }                       
                                i--;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    string[] tokens = input.Split(new char[] { '.', ')', '(' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string collection = tokens[0];
                    var methods = tokens.Skip(1).ToList();
                    if (!result.ContainsKey(collection))
                    {
                        result.Add(collection, methods);
                    }
                    else
                    {
                        foreach (var method in methods)
                        {
                            if (!result[collection].Contains(method))
                            {
                                result[collection].Add(method);
                            }
                        }
                    }
                }                
                input = Console.ReadLine();
            }
            string anotherInput = Console.ReadLine();
            string[] tokensTwo = anotherInput.Split(' ').ToArray();
            string method1 = tokensTwo[0];
            string selection = tokensTwo[1];
            if (selection == "collection")
            {
                foreach (var item in result.OrderByDescending(x=>x.Value.Count))
                {
                    if (item.Value.Contains(method1))
                    {
                        Console.WriteLine(item.Key);
                    }
                }
            }
            else
            {
                foreach (var item in result.OrderByDescending(x=>x.Value.Count))
                {
                    if (item.Value.Contains(method1))
                    {
                        Console.WriteLine(item.Key);
                        foreach (var method in item.Value.OrderByDescending(x=>x.Length))
                        {
                            Console.WriteLine($"* {method}");
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainlands
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> result = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            string trainName = "";
            string wagonName = "";
            int wagonPower = 0;
            while (input != "It's Training Men!")
            {
                string[] tokens = input.Split(new char[] { ' ', ':', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Contains("="))
                {
                    trainName = tokens[0];
                    string otherTrainName = tokens[2];
                    if (result.ContainsKey(trainName))
                    {
                        foreach (var key in result)
                        {
                            if (key.Key == otherTrainName)
                            {
                                result[trainName].Clear();
                                foreach (var value in key.Value)
                                {
                                    result[trainName].Add(value.Key, value.Value);
                                }
                            }
                        }
                    }
                    else
                    {
                        result.Add(trainName, new Dictionary<string, int>());
                        foreach (var key in result)
                        {
                            if (key.Key == otherTrainName)
                            {
                                foreach (var value in key.Value)
                                {
                                    result[trainName].Add(value.Key, value.Value);
                                }
                            }
                        }
                    }
                }
                else if (tokens.Length == 2)
                {
                    trainName = tokens[0];
                    string otherTrainName = tokens[1];
                    if (!result.ContainsKey(trainName))
                    {
                        result.Add(trainName, new Dictionary<string, int>());
                        foreach (var key in result)
                        {
                            if (key.Key == otherTrainName)
                            {
                                foreach (var value in key.Value)
                                {
                                    result[trainName].Add(value.Key, value.Value);
                                }
                            }
                        }
                        result.Remove(otherTrainName);
                    }
                    else
                    {
                        foreach (var key in result)
                        {
                            if (key.Key == otherTrainName)
                            {
                                foreach (var value in key.Value)
                                {
                                    result[trainName].Add(value.Key, value.Value);
                                }
                            }
                        }
                        result.Remove(otherTrainName);
                    }
                }
                else
                {
                    trainName = tokens[0];
                    wagonName = tokens[1];
                    wagonPower = int.Parse(tokens[2]);
                    if (!result.ContainsKey(trainName))
                    {
                        result.Add(trainName, new Dictionary<string, int>());
                        result[trainName].Add(wagonName, wagonPower);
                    }
                    else
                    {
                        if (!result[trainName].ContainsKey(wagonName))
                        {
                            result[trainName].Add(wagonName, wagonPower);
                        }                        
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in result.OrderByDescending(x=>x.Value.Values.Sum()).ThenBy(x=>x.Value.Count))
            {
                Console.WriteLine($"Train: {item.Key}");
                foreach (var value in item.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"###{value.Key} - {value.Value}");
                }
            }
        }
    }
}

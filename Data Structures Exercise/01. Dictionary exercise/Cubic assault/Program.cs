using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Cubic_assault
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<string, Meteors>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Count em all")
                {
                    break;
                }
                string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string regionName = tokens[0];
                string meteorType = tokens[1];
                long count = long.Parse(tokens[2]);
                if (!result.ContainsKey(regionName))
                {
                    Meteors meteor = new Meteors();
                    meteor = GiveMeteorValue(meteorType, meteor, count);
                    result.Add(regionName, meteor);
                }
                else
                {
                    IncreasingMeteorValues(meteorType, result, regionName, count);                   
                }               
            }
            foreach (var region in result)
            {
                if (region.Value.Green >= 1000000)
                {
                    long diff = region.Value.Green / 1000000;
                    region.Value.Green -= diff*1000000;
                    region.Value.Red += diff;
                }
                if (region.Value.Red >= 1000000)
                {
                    long diff = region.Value.Red / 1000000;
                    region.Value.Red -= diff*1000000;
                    region.Value.Black += diff;
                }
            }
            foreach (var region in result.OrderByDescending(x => x.Value.Black).ThenBy(x => x.Key.Length).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);
                Dictionary<string, long> print = new Dictionary<string, long>();
                print.Add("Black", region.Value.Black);
                print.Add("Red", region.Value.Red);
                print.Add("Green", region.Value.Green);
                foreach (var meteor in print.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
        private static void IncreasingMeteorValues(string meteorType, Dictionary<string, Meteors>result, string regionName, long count)
        {
            if (meteorType == "Green")
            {
                result[regionName].Green += count;
            }
            if (meteorType == "Red")
            {
                result[regionName].Red += count;
            }
            if (meteorType == "Black")
            {
                result[regionName].Black += count;
            }
        }

        private static Meteors GiveMeteorValue(string meteorType, Meteors meteor, long count)
        {
            if (meteorType == "Green")
            {
                meteor.Green = count;
            }
            if (meteorType == "Red")
            {
                meteor.Red = count;
            }
            if (meteorType == "Black")
            {
                meteor.Black = count;
            }
            return meteor;
        }
    }
    public class Meteors
    {
        public long Black { get; set; }
        public long Red { get; set; }
        public long Green { get; set; }
    }
}

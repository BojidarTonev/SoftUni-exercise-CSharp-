using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_army
{
    class Program
    {
        static void Main(string[] args)
        {
            double averageDamage = 0;
            double averageHealth = 0;
            double averageArmor = 0;
            var result = new Dictionary<string, Dictionary<string, List<int>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                string type = input[0];
                string name = input[1];
                int damage = 45;
                int health = 250;
                int armor = 10;
                if (input[2] != "null")
                {
                    damage = int.Parse(input[2]);
                }
                if (input[3] != "null")
                {
                    health = int.Parse(input[3]);
                }
                if (input[4] != "null")
                {
                    armor = int.Parse(input[4]);
                }
                if (!result.ContainsKey(type))
                {
                    result.Add(type, new Dictionary<string, List<int>>());
                    if (!result[type].ContainsKey(name))
                    {
                        result[type].Add(name, new List<int>());
                        result[type][name].Add(damage);
                        result[type][name].Add(health);
                        result[type][name].Add(armor);
                    }
                    else
                    {
                        result[type][name].Add(damage);
                        result[type][name].Add(health);
                        result[type][name].Add(armor);
                    }
                }
                else
                {
                    if (!result[type].ContainsKey(name))
                    {
                        result[type].Add(name, new List<int>());
                        result[type][name].Add(damage);
                        result[type][name].Add(health);
                        result[type][name].Add(armor);
                    }
                    else
                    {
                        result[type][name].Add(damage);
                        result[type][name].Add(health);
                        result[type][name].Add(armor);
                    }
                }
                if (result.ContainsKey(type))
                {
                    if (result[type].ContainsKey(name))
                    {
                        result[type][name].Clear();
                        result[type][name].Add(damage);
                        result[type][name].Add(health);
                        result[type][name].Add(armor);
                    }
                }
            }
            List<int> averageDmg = new List<int>();
            List<int> averageHP = new List<int>();
            List<int> averageArmorr = new List<int>();
            foreach (var dragon in result)
            {
                foreach (var item in dragon.Value)
                {
                    averageDmg.Add(item.Value[0]);
                    averageHP.Add(item.Value[1]);
                    averageArmorr.Add(item.Value[2]);
                }
                averageDamage = averageDmg.Average();
                averageHealth = averageHP.Average();
                averageArmor = averageArmorr.Average();
                Console.WriteLine($"{dragon.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var item in dragon.Value.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"-{item.Key} -> damage: {item.Value[0]}, health: {item.Value[1]}, armor: {item.Value[2]}");
                }
                averageDmg.Clear();
                averageHP.Clear();
                averageArmorr.Clear();
            }
        }
    }
}

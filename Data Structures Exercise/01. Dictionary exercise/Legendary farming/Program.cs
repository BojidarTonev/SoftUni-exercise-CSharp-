using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_farmingg
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            bool finish = false;
            int quantity = 0;
            string material = "";
            int shards = 0;
            int fragments = 0;
            int motes = 0;
            keyMaterials.Add("motes", 0);
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            while (true)
            {
                if (fragments >= 250 || shards >= 250 || motes >= 250)
                {
                    break;
                }
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int i = 0; i < tokens.Length - 1; i++)
                {
                    quantity = int.Parse(tokens[i]);
                    i++;
                    material = tokens[i].ToLower();

                    if (material == "motes")
                    {
                        keyMaterials[material] += quantity;
                        motes += quantity;
                        if (motes >= 250)
                        {
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                    else if (material == "fragments")
                    {
                        keyMaterials[material] += quantity;
                        fragments += quantity;
                        if (fragments >= 250)
                        {
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                    else if (material == "shards")
                    {
                        keyMaterials[material] += quantity;
                        shards += quantity;
                        if (shards >= 250)
                        {
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials.Add(material, quantity);
                        }
                    }
                }
            }
            if (shards >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (fragments >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else if (motes >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
            }
            foreach (var item in keyMaterials.OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

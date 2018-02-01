using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Hornet_assault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            long hornetPower = hornets.Sum();
            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornetPower>beehives[i])
                {
                    beehives[i] = 0;
                }
                else if (hornetPower == beehives[i])
                {
                    beehives[i] = 0;
                    if (hornets.Count>0)
                    {
                        hornets.Remove(hornets[0]);
                    }
                    else
                    {
                        break;
                    }
                    hornetPower = hornets.Sum();
                }
                else
                {
                    beehives[i] -= hornetPower;
                    if (hornets.Count>0)
                    {
                        hornets.Remove(hornets[0]);
                    }
                    else
                    {
                        break;
                    }
                    hornetPower = hornets.Sum();
                }
            }

            beehives.RemoveAll(x => x.Equals(0));
            if (beehives.Count>0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }           
        }
    }
}

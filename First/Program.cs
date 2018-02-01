using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANO_VZEMA_TOQ_IZPIT_VECHE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Snowball> result = new List<Snowball>();
            long n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                long snowballSnow = long.Parse(Console.ReadLine());
                long snowballTime = long.Parse(Console.ReadLine());
                long snowballQuality = long.Parse(Console.ReadLine());
                double smetka = snowballSnow / snowballTime;
                double snowballValue = Math.Pow(smetka, snowballQuality);
                Snowball snowball = new Snowball(){SnowballSnow = snowballSnow, SnowballTime = snowballTime, SnowballQuality = snowballQuality, SnowballValue = snowballValue};
                if (result.Count==0)
                {
                    result.Add(snowball);
                }
                else
                {
                    if (snowballValue>result[0].SnowballValue)
                    {
                        result.Clear();
                        result.Add(snowball);
                    }
                }
            }
            foreach (var item in result)
            {
                Console.WriteLine($"{item.SnowballSnow} : {item.SnowballTime} = {item.SnowballValue} ({item.SnowballQuality})");
                break;
            }
            
        }
    }

    public class Snowball
    {
        public long SnowballSnow { get; set; }
        public long SnowballTime { get; set; }
        public long SnowballQuality { get; set; }
        public double SnowballValue { get; set; }
    }
}

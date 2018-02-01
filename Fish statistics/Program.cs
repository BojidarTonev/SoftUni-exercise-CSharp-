using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fish_statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            int tailCM = 0;
            int bodyCM = 0;
            bool show = true;
            string tailType = "";
            string bodyType = "";
            string fishStatus = "";
            string input = Console.ReadLine();
            string pattern = @"([>]*?)<+([(]+)('|-|x)>";
            foreach (Match m in Regex.Matches(input, pattern))
            {
                if (m.Groups[1].Value.Length>5)
                {
                    tailType = "Long";
                    tailCM = m.Groups[1].Value.Length * 2;
                }
                else if (m.Groups[1].Value.Length > 1 && m.Groups[1].Value.Length < 5)
                {
                    tailType = "Medium";
                    tailCM = m.Groups[1].Value.Length * 2;
                }
                else if (m.Groups[1].Value.Length == 1)
                {
                    tailType = "Short";
                    tailCM = m.Groups[1].Value.Length * 2;
                }
                else
                {
                    tailType = "None";
                    show = false;
                }
                if (m.Groups[2].Value.Length>10)
                {
                    bodyType = "Long";
                    bodyCM = m.Groups[2].Value.Length * 2;
                }
                else if (m.Groups[2].Value.Length>=5 && m.Groups[2].Value.Length<10)
                {
                    bodyType = "Medium";
                    bodyCM = m.Groups[2].Value.Length * 2;
                }
                else
                {
                    bodyType = "Short";
                    bodyCM = m.Groups[2].Value.Length * 2;
                }
                if (m.Groups[3].Value.Equals("'"))
                {
                    fishStatus = "Awake";
                }
                else if (m.Groups[3].Value.Equals("-"))
                {
                    fishStatus = "Asleep";
                }
                else
                {
                    fishStatus = "Dead";
                }
                Console.WriteLine($"Fish {count}: {m}");
                if (show)
                {
                    Console.WriteLine($"  Tail type: {tailType} ({tailCM} cm)");
                }
                else
                {
                    Console.WriteLine($"  Tail type: {tailType}");
                }      
                Console.WriteLine($"  Body type: {bodyType} ({bodyCM} cm)");
                Console.WriteLine($"  Status: {fishStatus}");
                count++;
                show = true;
            } //end while
            if (count == 1)
            {
                Console.WriteLine("No fish found.");
            }
        }
    }
}

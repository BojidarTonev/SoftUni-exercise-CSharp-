using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> matches = new List<string>();
            string input = Console.ReadLine();
            string pattern = @"[2-9JQKA][SHDC]|10[SHDC]";
            input = string.Join("", input.Trim());
            

            foreach (Match m in Regex.Matches(input, pattern))
            {
                matches.Add(m.ToString());
            }
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}

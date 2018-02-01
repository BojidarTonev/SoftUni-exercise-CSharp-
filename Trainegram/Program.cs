using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trainegram
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(<\[[^a-zA-Z0-9]*\]\.)(\.\[[a-zA-Z0-9]*\]\.)*$";
            List<string> result = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Traincode!")
                {
                    break;
                }
                if (Regex.IsMatch(input, pattern))
                {
                    result.Add(input);
                }
            }
            foreach (var VARIABLE in result)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}

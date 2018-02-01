using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace phoenix_grid
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string validationPattern = @"^([^\s_]{3})(\.[^\s_]{3})*$";

            while (true)
            {
                if (input == "ReadMe")
                {
                    break;
                }
                var validation = Regex.Match(input, validationPattern);
                if (validation.Success)
                {
                    string value = validation.ToString();
                    string palindrome = "";
                    for (int i = value.Length-1; i >= 0; i--)
                    {
                        palindrome += value[i];
                    }
                    if (palindrome == value)
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }
                input = Console.ReadLine();
            }
        }
    }
}

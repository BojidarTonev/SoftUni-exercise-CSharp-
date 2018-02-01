using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnowFlake
{
    class Program
    {
        static void Main(string[] args)
        {
            int coreLength = 0;
            string surfaceRegex = @"^[^a-zA-Z\d]+$";
            string mantleRegex = @"^[\d_]+$";
            string coreRegex = @"[a-zA-Z]+";
            string bigInputRegex = @"(^[^a-zA-Z\d]+)([\d\-]+)([a-zA-Z]+)([\d\-]+)([^a-zA-Z]+)$";

            string surfaceInput = Console.ReadLine();
            if (Regex.IsMatch(surfaceInput, surfaceRegex))
            {
                string mantleInput = Console.ReadLine();
                if (Regex.IsMatch(mantleInput, mantleRegex))
                {
                    string bigInput = Console.ReadLine();
                    if (Regex.IsMatch(bigInput, bigInputRegex))
                    {
                        string core = Regex.Match(bigInput, coreRegex).Value;
                        coreLength = core.Length;
                        string mantleeInput = Console.ReadLine();
                        if (Regex.IsMatch(mantleeInput, mantleRegex))
                        {
                            string surfaceeInput = Console.ReadLine();
                            if (Regex.IsMatch(surfaceeInput, surfaceRegex))
                            {
                                Console.WriteLine("Valid");
                                Console.WriteLine(coreLength);
                            }
                            else
                            {
                                Console.WriteLine("Invalid");
                                Console.WriteLine(coreLength);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid");
                            Console.WriteLine(coreLength);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                        Console.WriteLine(coreLength);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

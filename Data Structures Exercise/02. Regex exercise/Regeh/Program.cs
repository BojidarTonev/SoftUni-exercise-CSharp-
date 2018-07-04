using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace Greedy_times
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\[\w+(<(\d+)REGEH(\d+)>)\w+\]";
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();

            foreach (Match m in Regex.Matches(input, pattern))
            {
                numbers.Add(int.Parse(m.Groups[2].Value));
                numbers.Add(int.Parse(m.Groups[3].Value));
            }
            StringBuilder result = new StringBuilder();

            int index = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                index += numbers[i];
                if (index > input.Length)
                {
                    index -= input.Length -1;
                }
                result.Append(input[index]);
            }
            Console.WriteLine(result);
        }
    }
}
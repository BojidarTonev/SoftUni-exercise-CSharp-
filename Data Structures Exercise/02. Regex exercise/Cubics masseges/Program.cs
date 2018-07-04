using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace Cubics_masseges
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([0-9]+)([a-zA-Z]+)([^a-zA-Z]+)$";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Over!")
                {
                    break;
                }
                int number = int.Parse(Console.ReadLine());
                List<int> numbers = new List<int>();

                foreach (Match m in Regex.Matches(input, pattern))
                {
                    string firstPairNumbers = m.Groups[1].Value;
                    string massege = m.Groups[2].Value;
                    string secondPairNumbers = m.Groups[3].Value;
                    numbers.AddRange(firstPairNumbers.Select(x => int.Parse(x.ToString())).ToArray());
                    for (int i = 0; i < secondPairNumbers.Length; i++)
                    {
                        if (char.IsDigit(secondPairNumbers[i]))
                        {
                            int numberr = int.Parse(secondPairNumbers[i].ToString());
                            numbers.Add(numberr);
                        }
                    }       

                    if (massege.Length == number)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < massege.Length)
                            {
                                int index = numbers[i];
                                sb.Append(massege[index]);
                            }
                            else
                            {
                                sb.Append(" ");
                            }
                        }
                        Console.WriteLine($"{massege} == {sb}");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Valid_usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ', ')', '(', '/', '\\'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> validUsernames = new List<string>();
            string usernamePattern = @"^[a-zA-Z][\w]{2,24}$";
            int biggestSum = 0;
            string result = "";

            foreach (var item in input)
            {
                Match match = Regex.Match(item, usernamePattern);
                if (match.Success)
                {
                    validUsernames.Add(item);
                }
            }
            for (int i = 0; i < validUsernames.Count; i++)
            {
                if (i + 2 > validUsernames.Count)
                {
                    break;
                }
                int sum = validUsernames[i].Length + validUsernames[i + 1].Length;
                if (sum>biggestSum)
                {
                    biggestSum = sum;
                    result = validUsernames[i] + "\n" + validUsernames[i + 1];
                }
            }
            Console.WriteLine(result);
        }
    }
}

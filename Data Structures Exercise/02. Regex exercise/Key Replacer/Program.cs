using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = Console.ReadLine();
            string keyPattern = @"^([a-zA-Z]+)[\|\<\\]?[\w]*[\|\<\\]([a-zA-Z]+)$";

            Match match = Regex.Match(key, keyPattern);
            if (match.Success)
            {
                string start = match.Groups[1].ToString();
                string end = match.Groups[2].ToString();

                string textPattern = $@"(?:{start})(.*?)(?:{end})";
                StringBuilder result = new StringBuilder();
                var matches = Regex.Matches(text, textPattern);
                foreach (Match m in matches)
                {
                    result.Append(m.Groups[1].Value);
                }
                if (result.Length==0)
                {
                    Console.WriteLine("Empty result");
                }
                else
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.XPath;

namespace Query_Mess
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            List<string> items = new List<string>();
            List<string> values = new List<string>();
            var urlDetect = @"^(https://|http://)";

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "END")
                {
                    break;
                }
                Regex transform = new Regex(@"%20");
                input = transform.Replace(input, "%");
                Regex spaceReplace = new Regex(@"([[+\%])");
                input = spaceReplace.Replace(input, " ");
                Regex spaceRemove = new Regex("[ ]{2,}", RegexOptions.None);
                input = spa.ceRemove.Replace(input, " ");
                var match = Regex.Match(input, urlDetect);
                if (match.Success)
                {
                    string[] tokens = input.Split('?');
                    input = tokens[1];
                }
                items = input.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in items)
                {
                    string[] tokens = item.Split('=');
                    string key = tokens[0].Trim();
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        values.Add(tokens[i].Trim());
                    }
                    if (!result.ContainsKey(key))
                    {
                        result.Add(key, new List<string>());
                        result[key].AddRange(values);
                    }
                    else
                    {
                        result[key].AddRange(values);
                    }
                    values.Clear();
                }
                foreach (var key in result)
                {
                    Console.Write($"{key.Key}=");
                    string value = string.Join(", ", key.Value);
                    Console.Write($"[{value}]");
                }
                result.Clear();
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}

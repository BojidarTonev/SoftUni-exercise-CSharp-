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
            List<string> values = new List<string>();
            bool isLink = false;
            string patternRemove = @"[%20]{3}";
            string patternGroup = @"";

            string input = Console.ReadLine();
            while (true)
            {
                if (input == "END")
                {
                    break;
                }
                string linkPattern = (@"^[http]*");
                var link = Regex.Match(input, linkPattern);
                if (link.Success)
                {
                    //Regex urlSplitter = new Regex(@"[?]{1}(.)*");
                    string[] tokens = input.Split('?');
                    string key = tokens[0];
                    for (int i = 1; i < ; i++)
                    {
                        
                    }

                }
                
                var match = Regex.Matches(input, patternRemove);
                foreach (Match m in match)
                {
                    string ma = m.ToString();
                    input = input.Replace(ma, "%");
                }
                Regex spaceDetect = new Regex(@"([+\%])");
                input = spaceDetect.Replace(input, " ");

                Regex regex = new Regex("[ ]{2,}", RegexOptions.None);
                input = regex.Replace(input, " ");
                List<string> items = input.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var item in items)
                {
                    string[] tokens = item.Split('=');
                    string key = tokens[0].Trim();
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        values.Add(tokens[i].Trim());
                    }
                    string keyValue = string.Join(", ", values);
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


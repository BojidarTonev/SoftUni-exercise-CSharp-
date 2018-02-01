using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedMessage = Console.ReadLine();
            List<string> values = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string extractPattern = @"([a-zA-Z]+)(.*)(\1)+";

            foreach (Match m in Regex.Matches(encodedMessage, extractPattern))
            {
                int i = 0;
                string newValue = m.Groups[2].Value;
                encodedMessage = Regex.Replace(encodedMessage, newValue, values[i]);
                if (i<values.Count)
                {
                    values.RemoveAt(i);
                    i++;
                }
            }          
            Console.WriteLine(encodedMessage);
        }
    }
}

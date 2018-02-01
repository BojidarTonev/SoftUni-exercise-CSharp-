using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hornet_comm
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternPrivateMessage = "^([0-9]+) <-> ([a-zA-Z0-9]+)$";
            string patternBroadcast = "^([^0-9]+) <-> ([a-zA-Z0-9]+)$";

            List<string> recipantCodeMessages = new List<string>();
            List<string> frequencies = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Hornet is Green")
                {
                    break;
                }
                if (Regex.IsMatch(input,patternPrivateMessage))
                {
                    Match data = Regex.Match(input, patternPrivateMessage);
                    string recipantCode = data.Groups[1].ToString();
                    string massege = data.Groups[2].ToString();
                    char[] chars = recipantCode.ToCharArray();
                    Array.Reverse(chars);
                    string result =  new string(chars);
                    recipantCodeMessages.Add(result + " -> " + massege);
                }
                if (Regex.IsMatch(input, patternBroadcast))
                {
                    Match message = Regex.Match(input, patternBroadcast);
                    string massege = message.Groups[1].ToString();
                    string frequency = message.Groups[2].ToString();
                    string frequencyResult = "";
                    for (int i = 0; i < frequency.Length; i++)
                    {
                        if (char.IsLower(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToUpper();
                        }
                        else if(char.IsUpper(frequency[i]))
                        {
                            frequencyResult += frequency[i].ToString().ToLower();
                        }
                        else
                        {
                            frequencyResult += frequency[i];
                        }
                    }
                    frequencies.Add(frequencyResult + " -> " + massege);
                }
            }
            Console.WriteLine("Broadcasts:");
            if (frequencies.Count>0)
            {
                foreach (var frequency in frequencies)
                {
                    Console.WriteLine(frequency);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (recipantCodeMessages.Count>0)
            {
                foreach (var message in recipantCodeMessages)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}

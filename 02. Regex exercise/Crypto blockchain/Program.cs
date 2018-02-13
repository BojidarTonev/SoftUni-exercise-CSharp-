using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Crypto_blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int cryptoBlockLength = 0;
            List<int> matches = new List<int>();
            string regexPattern = @"\[[^\d]*([0-9]{3,})[^\d]*\]|\{[^\d]*([0-9]{3,})[^\d]*\}";
            int n = int.Parse(Console.ReadLine());
            string fullMassege = "";
            for (int i = 0; i < n; i++)
            {
                fullMassege += Console.ReadLine();
            }
            foreach (Match m in Regex.Matches(fullMassege, regexPattern))
            {
                if (m.Groups[1].Value.Length % 3 == 0)
                {
                    string number = m.Groups[1].Value;
                    for (int i = 0; i < number.Length; i +=3)
                    {
                        cryptoBlockLength = m.Length;
                        string buildNumber = number.Substring(i, 3);
                        int numberr = int.Parse(buildNumber);
                        numberr -= cryptoBlockLength;
                        matches.Add(numberr);
                    }
                }
                if (m.Groups[2].Value.Length % 3 == 0)
                {
                    string number = m.Groups[2].Value;
                    for (int i = 0; i < number.Length; i +=3)
                    {
                        cryptoBlockLength = m.Length;
                        string buildNumber = number.Substring(i, 3);
                        int numberr = int.Parse(buildNumber);
                        numberr -= cryptoBlockLength;
                        matches.Add(numberr);
                    }
                }
            }
            for (int i = 0; i < matches.Count; i++)
            {
                Console.Write((char)matches[i]);
            }
            Console.WriteLine();
        }
    }
}

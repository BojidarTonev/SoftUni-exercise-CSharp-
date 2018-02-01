using System;
using System.Text.RegularExpressions;

namespace Happiness_index
{
    class Program
    {
        static void Main(string[] args)
        {
            string emotion = "";
            int happyCount = 0;
            int sadCount = 0;
            double result = 0;
            string happyRegex = @"(:\)|:D|;\)|:\*|:\]|;\]|:}|;}|\(:|\*:|c:|\[:|\[;)";
            string sadRegex = @"(:\(|D:|;\(|:\[|;\[|:{|;{|\):|:c|]:|\]f;)";


            string input = Console.ReadLine();
            foreach (Match m in Regex.Matches(input, happyRegex))
            {
                happyCount++;
            }
            foreach (Match m in Regex.Matches(input, sadRegex))
            {
                sadCount++;
            }
            result = (double)happyCount / sadCount;


            Math.Round(result, 2);



            if (result < 1)
            {
                emotion = ":(";
            }
            if (result >0.999 && result < 1.001)
            {
                emotion = ":|";
            }
            if (result > 1)
            {
                emotion = ":)";
            }
            if (result >= 2)
            {
                emotion = ":D";
            }
            
            Console.WriteLine($"Happiness index: {result:f2} {emotion}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }
    }
}

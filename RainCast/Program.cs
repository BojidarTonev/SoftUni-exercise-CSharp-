using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RainCast
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = "";
            string source = "";
            string forecast = "";

            string typePattern = @"Type: (Normal|Warning|Danger)";
            string sourcePattern = @"(Source: )([a-zA-Z0-9]+)";
            string forecastPattern = @"(Forecast: )([\w]*[^\!\.\?\, ]*[\w ]+)";

            bool typee = true;
            bool sourcee = false;
            bool forecastt = false;
            List <string>result = new List<string>();

            string input = Console.ReadLine();
            while (input != "Davai Emo")
            {
                if (typee)
                {
                    var typeMatch = Regex.Match(input, typePattern);
                    if (typeMatch.Success)
                    {
                        type = typeMatch.Groups[1].Value;
                        typee = false;
                        sourcee = true;
                    }
                }
                if (sourcee)
                {
                    var sourceMatch = Regex.Match(input, sourcePattern);
                    if (sourceMatch.Success)
                    {
                        source = sourceMatch.Groups[2].Value;
                        sourcee = false;
                        forecastt = true;
                    }
                }
                if (forecastt)
                {
                    var forecastMatch = Regex.Match(input, forecastPattern);
                    if (forecastMatch.Success)
                    {
                        forecast = forecastMatch.Groups[2].Value;
                        forecastt = false;
                        typee = true;
                    }
                }
                if (type != "" && source != "" && forecast != "")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"({type}) ");
                    sb.Append($"{forecast} ~ ");
                    sb.Append(source);
                    string resultt = sb.ToString();
                    result.Add(resultt);
                    sb.Clear();
                    type = "";
                    source = "";
                    forecast = "";
                }
                input = Console.ReadLine();
            }
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}

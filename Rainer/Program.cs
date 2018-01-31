using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int donaldIndex = input.Last();
            input.RemoveRange(input.Count - 1, 1);
            List<int> playField = new List<int>(input);
            int stepCounts = 0;

            while (true)
            {
                for (int i = 0; i < playField.Count; i++)
                {
                    if (playField[i] != 0)
                    {
                        playField[i] -= 1;
                    }                    
                }
                if (playField[donaldIndex] == 0)
                {
                    break;
                }
                else
                {
                    for (int i = 0; i < playField.Count; i++)
                    {
                        if (playField[i] == 0)
                        {
                            playField[i] = input[i];
                        }
                    }
                }
                donaldIndex = int.Parse(Console.ReadLine());
                stepCounts++;
            }
            Console.WriteLine(string.Join(" ", playField));
            Console.WriteLine(stepCounts);
        }
    }
}

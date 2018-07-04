using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string result = string.Empty;
            Stack<string> previousCommand = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                int operation = int.Parse(input[0]);
                if (operation == 1)
                {
                    previousCommand.Push(result);
                    result += input[1];
                    
                }
                if (operation == 2)
                {
                    previousCommand.Push(result);
                    int count = int.Parse(input[1]);
                    result = result.Substring(0, result.Length-count);
                    
                }
                if (operation == 3)
                {
                    Console.WriteLine($"{result.ElementAt(int.Parse(input[1]) - 1)}");
                }
                if (operation == 4)
                {
                    result = previousCommand.Pop();
                }
            }
        }
    }
}
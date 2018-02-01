using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_paranthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool print = false;
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            var input = Console.ReadLine().ToCharArray();
            char[] openingBrackets = new[] { '(', '[', '{' };
            char[] closingBrackets = new[] { ')', ']', '}' };
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (openingBrackets.Contains(input[i]))
                {
                    queue.Enqueue(input[i]);
                }
            }
            for (int i = input.Length / 2; i < input.Length; i++)
            {
                if (closingBrackets.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
            }
            for (int i = 0; i < queue.Count; i++)
            {
                char openingBracket = queue.Dequeue();
                char closingBracket = stack.Pop();
                if (openingBracket == '{')
                {
                    if (closingBracket != '}')
                    {
                        print = true;
                        break;
                    }
                }
                else if (openingBracket == '[')
                {
                    if (closingBracket != ']')
                    {
                        print = true;
                        break;
                    }
                }
                else if (openingBracket == '{')
                {
                    if (closingBracket != '}')
                    {
                        print = true;
                        break;
                    }
                }
            }
            if (print)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
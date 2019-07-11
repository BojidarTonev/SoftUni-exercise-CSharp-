using System;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stackk<int> stack = new Stackk<int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                var tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens[0] == "Push")
                {
                    var items = tokens.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(items);
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }

            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }

            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }
        }
    }
}

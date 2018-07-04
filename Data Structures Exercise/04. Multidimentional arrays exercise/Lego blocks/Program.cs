using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lego_blocks_new
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] firstJagged = new char[n][];
            char[][] secondJagged = new char[n][];
            bool lengthsAreEqual = false;
            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                firstJagged[i] = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    firstJagged[i][j] = input[j];
                    counter++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                secondJagged[i] = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    secondJagged[i][j] = input[j];
                    counter++;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                lengthsAreEqual = firstJagged[i].Length + secondJagged[i].Length == firstJagged[i + 1].Length + secondJagged[i + 1].Length;
            }
            if (lengthsAreEqual)
            {
                for (int i = 0; i < n; i++)
                {
                    char[] row = secondJagged[i].ToArray();
                    Array.Reverse(row);
                    secondJagged[i] = row;
                }
                for (int i = 0; i < n; i++)
                {
                    Print(firstJagged, secondJagged, i);                    
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {counter}");
            }
        }
        private static void Print(char[][]firstJagged, char[][]secondJagged, int i)
        {
            Console.Write('[');
            var firstPrint = new List<string>();
            for (int j = 0; j < firstJagged[i].Length; j++)
            {
                firstPrint.Add(firstJagged[i][j].ToString());
            }
            Console.Write(string.Join(", ", firstPrint));
            if (secondJagged[i].Length > 0)
            {
                Console.Write(", ");
            }
            var secondPrint = new List<string>();
            for (int j = 0; j < secondJagged[i].Length; j++)
            {
                secondPrint.Add(secondJagged[i][j].ToString());
            }
            Console.Write(string.Join(", ", secondPrint));
            Console.Write(']');
            Console.WriteLine();
        }
    }
}

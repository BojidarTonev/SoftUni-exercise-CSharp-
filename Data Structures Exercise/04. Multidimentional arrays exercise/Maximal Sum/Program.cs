using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            int[,]matrix = new int[rows,columns];

            for (int i = 0; i < rows; i++)
            {
                int[] secondInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = secondInput[j];
                }
            }
            List<int> numbers = new List<int>();
            int biggestSum = 0;
            int sum = 0;

            for (int i = 0; i < rows-2; i++)
            {
                for (int j = 0; j < columns-2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] +
                          matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        numbers.Clear();
                        for (int k = 0; k < 3; k++)
                        {
                            for (int l = 0; l < 3; l++)
                            {
                                numbers.Add(matrix[i+k, j + l]);
                            }                             
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {biggestSum}");
            for (int i = 0; i < 9; i++)
            {
                if (i>0 && i%3==0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
        }
    }
}

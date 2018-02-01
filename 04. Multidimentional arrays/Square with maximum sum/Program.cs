using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_with_maximum_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int topLeft = 0;
            int topRight = 0;
            int botLeft = 0;
            int botRight = 0;
            int sum = 0;

            int[] input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            int[,]matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                int[] matrixInput = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = matrixInput[j];
                }
            }

            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < columns-1; j++)
                {
                    int total = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    if (sum<total)
                    {
                        sum = total;
                        topLeft = matrix[i, j];
                        topRight = matrix[i, j + 1];
                        botLeft = matrix[i + 1, j];
                        botRight = matrix[i + 1, j + 1];
                    }
                }
            }
            Console.WriteLine($"{topLeft} {topRight}");
            Console.WriteLine($"{botLeft} {botRight}");
            Console.WriteLine(sum);




        }
    }
}

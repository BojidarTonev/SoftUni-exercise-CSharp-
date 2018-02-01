using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2x2_Squares_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[]input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            string[,] matrix = new string[rows,columns];
            int counter = 0;
            for (int i = 0; i < rows; i++)
            {
                var matrixInput = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = matrixInput[j];
                }
            }
            for (int i = 0; i < rows-1; i++)
            {
                for (int j = 0; j < columns-1; j++)
                {
                    if (matrix[i, j].Equals(matrix[i, j+1]))
                    {
                        if (matrix[i, j].Equals(matrix[i+1, j+1]))
                        {
                            if (matrix[i, j].Equals(matrix[i+1, j]))
                            {
                                counter++;
                            }
                        }
                        
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> inputCollector = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                inputCollector.Add(input);
            }
            int matrixLength = inputCollector[0].Length;
            char[,] matrix = new char[n, matrixLength];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < inputCollector[i].Length; j++)
                {
                    matrix[i, j] = inputCollector[i][j];
                }
            }

            int SamRow = 0;
            int SamCol = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        SamRow = i;
                        SamCol = j;
                        break;
                    }
                }
            }

            int NikoladzeRow = 0;
            int NikoladzeCol = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrix[i, j] == 'N')
                    {
                        NikoladzeRow = i;
                        NikoladzeCol = j;
                        break;
                    }
                }
            }

            string secondInput = Console.ReadLine();
            for (int z = 0; z < secondInput.Length; z++)
            {
                if (secondInput[z] == 'U')
                {
                    //Sam moves up
                    PeonsMove(n, matrixLength, matrix);
                    for (int i = 0; i < SamCol; i++)
                    {
                        if (matrix[SamRow, i] == 'b')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    for (int i = SamCol; i < matrixLength; i++)
                    {
                        if (matrix[SamRow, i] == 'd')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    matrix[SamRow, SamCol] = '.';
                    SamRow--;
                    matrix[SamRow, SamCol] = 'S';                  
                    if (NikoladzeRow == SamRow)
                    {
                        matrix[NikoladzeRow, NikoladzeCol] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        PrintMatrix(matrix, n, matrixLength);
                        return;
                    }
                }
                if (secondInput[z] == 'W')
                {
                    //Sam waits
                    PeonsMove(n, matrixLength, matrix);
                }
                if (secondInput[z] == 'D')
                {
                    //Sam moves down
                    PeonsMove(n, matrixLength, matrix);
                    for (int i = 0; i < SamCol; i++)
                    {
                        if (matrix[SamRow, i] == 'b')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    for (int i = SamCol; i < matrixLength; i++)
                    {
                        if (matrix[SamRow, i] == 'd')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    matrix[SamRow, SamCol] = '.';
                    SamRow++;
                    matrix[SamRow, SamCol] = 'S';
                    if (NikoladzeRow == SamRow)
                    {
                        matrix[NikoladzeRow, NikoladzeCol] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        PrintMatrix(matrix, n, matrixLength);
                        break;
                    }
                }
                if (secondInput[z] == 'R')
                {
                    //Sam moves right
                    PeonsMove(n, matrixLength, matrix);
                    for (int i = 0; i < SamCol; i++)
                    {
                        if (matrix[SamRow, i] == 'b')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    for (int i = SamCol; i < matrixLength; i++)
                    {
                        if (matrix[SamRow, i] == 'd')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    matrix[SamRow, SamCol] = '.';
                    SamCol++;
                    matrix[SamRow, SamCol] = 'S';
                    if (NikoladzeRow == SamRow)
                    {
                        matrix[NikoladzeRow, NikoladzeCol] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        PrintMatrix(matrix, n, matrixLength);
                        return;
                    }
                }
                if (secondInput[z] == 'L')
                {
                    //Sam moves left
                    PeonsMove(n, matrixLength, matrix);
                    for (int i = 0; i < SamCol; i++)
                    {
                        if (matrix[SamRow, i] == 'b')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    for (int i = SamCol; i < matrixLength; i++)
                    {
                        if (matrix[SamRow, i] == 'd')
                        {
                            //Sam is dead
                            matrix[SamRow, SamCol] = 'X';
                            Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                            PrintMatrix(matrix, n, matrixLength);
                            return;
                        }
                    }
                    matrix[SamRow, SamCol] = '.';
                    SamCol--;
                    matrix[SamRow, SamCol] = 'S';
                    if (NikoladzeRow == SamRow)
                    {
                        matrix[NikoladzeRow, NikoladzeCol] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        PrintMatrix(matrix, n, matrixLength);
                        return;
                    }
                }
            }
        }

        private static void PeonsMove(int n, int matrixLength, char[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrix[i, j] == 'b')
                    {
                        if (j == matrixLength - 1)
                        {
                            matrix[i, j] = 'd';
                            break;
                        }
                        else
                        {
                            matrix[i, j] = '.';
                            matrix[i, j + 1] = 'b';
                            break;
                        }
                    }
                    if (matrix[i, j] == 'd')
                    {
                        if (j == 0)
                        {
                            matrix[i, j] = 'b';
                            break;
                        }
                        else
                        {
                            matrix[i, j] = '.';
                            matrix[i, j - 1] = 'd';
                            break;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix, int n, int matrixLength)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

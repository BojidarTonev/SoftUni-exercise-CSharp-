using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        public static char[,] matrix;
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            matrix = new char[rows, columns];
            string snakeInput = Console.ReadLine();
            CreateAndFillMatrix(snakeInput, input, matrix, rows, columns);

            var secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            ShotAndFallDown(secondInput, rows, columns);

            Print(rows, columns);
            
        }

        private static void Print(int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void ShotAndFallDown(int[] secondInput, int rows, int columns)
        {
            int damagedX = secondInput[0];
            int damagedY = secondInput[1];
            int damageRadius = secondInput[2];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (IsCellShot(i, j, damagedX, damagedY, damageRadius))
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }

            for (int z = 0; z < rows; z++)
            {
                for (int i = 0; i < rows - 1; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (matrix[i + 1, j] == ' ')
                        {
                            matrix[i + 1, j] = matrix[i, j];
                            matrix[i, j] = ' ';
                        }
                    }
                }
            }
        }

        private static bool IsCellShot(int i, int j, int damagedX, int damagedY, int damagedRadius)
        {
            var distance = Math.Sqrt((j - damagedY) * (j - damagedY) + (i - damagedX) * (i - damagedX));
            return distance <= damagedRadius;
        }

        public static void CreateAndFillMatrix(string snakeInput, int[]input, char[,]matrix, int rows, int columns)
        {
            
            int counter = 0;
            int snakeCounter = 0;
            for (int i = rows - 1; i >= 0; i--)
            {
                //move string to left
                if (counter % 2 == 0)
                {
                    for (int j = columns - 1; j >= 0; j--)
                    {
                        if (snakeCounter < snakeInput.Length)
                        {
                            matrix[i, j] = snakeInput[snakeCounter];
                            snakeCounter++;
                        }
                        else
                        {
                            snakeCounter = 0;
                            matrix[i, j] = snakeInput[snakeCounter];
                            snakeCounter++;
                        }

                    }
                }
                //move string to right
                else
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (snakeCounter < snakeInput.Length)
                        {
                            matrix[i, j] = snakeInput[snakeCounter];
                            snakeCounter++;
                        }
                        else
                        {
                            snakeCounter = 0;
                            matrix[i, j] = snakeInput[snakeCounter];
                            snakeCounter++;
                        }
                    }
                }
                counter++;
            }
        }
    }
}

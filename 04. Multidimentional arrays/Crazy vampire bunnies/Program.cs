using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crazy_bunnies
{
    class Program
    {
        public static char[,] matrix;
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
            matrix = new char[rows, columns];
            int[] player = new int[2];
            for (int i = 0; i < rows; i++)
            {
                string matrixInput = Console.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = matrixInput[j];
                    if (matrixInput[j] == 'P')
                    {
                        player[0] = i;
                        player[1] = j;
                    }
                }
            }
            int playerRow = player[0];
            int playerColumn = player[1];
            bool finishAlive = false;
            bool finishDead = false;
            string moves = Console.ReadLine();
            bool[] array = new bool[]{finishAlive, finishDead};
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'U')
                {
                    playerRow = MoveUp(playerRow, array, playerColumn);
                }
                if (moves[i] == 'L')
                {
                    playerColumn = MoveLeft(playerRow, array, playerColumn);                   
                }
                if (moves[i] == 'D')
                {
                    playerRow = MoveDown(playerRow, array, playerColumn, rows);                    
                }
                if (moves[i] == 'R')
                {
                    playerColumn = MoveRight(playerRow, array, playerColumn, columns);                   
                }
                AddNewBunnies(rows, columns, finishAlive, finishAlive);
            }
            if (array[0] = true)
            {
                AddNewBunnies(rows, columns, finishAlive, finishAlive);
                print(rows, columns, matrix);
                Console.WriteLine($"dead: {playerRow} {playerColumn}");
            }
            else
            {
                matrix[playerRow, playerColumn] = '.';
                AddNewBunnies(rows, columns, finishAlive, finishAlive);
                print(rows, columns, matrix);
                Console.WriteLine($"won: {playerRow} {playerColumn}");
            }
        }

        private static int MoveRight(int playerRow, bool[] array, int playerColumn, int columns)
        {
            if (playerColumn == columns - 1)
            {
                array[0] = true;
            }
            else
            {
                if (matrix[playerRow, playerColumn + 1] == 'B')
                {
                    playerColumn += 1;
                    array[1] = true;
                }
                else
                {
                    matrix[playerRow, playerColumn] = '.';
                    matrix[playerRow, playerColumn + 1] = 'P';
                    playerColumn += 1;
                }
            }
            return playerColumn;
        }

        private static int MoveDown(int playerRow, bool[] array, int playerColumn, int rows)
        {
            if (playerRow == rows - 1)
            {
                array[0] = true;
            }
            else
            {
                if (matrix[playerRow + 1, playerColumn] == 'B')
                {
                    playerRow += 1;
                    array[1] = true;
                }
                else
                {
                    matrix[playerRow, playerColumn] = '.';
                    matrix[playerRow + 1, playerColumn] = 'P';
                    playerRow += 1;
                }
            }
            return playerRow;
        }

        private static int MoveLeft(int playerRow, bool[] array, int playerColumn)
        {
            if (playerColumn == 0)
            {
                array[0] = true;
            }
            else
            {
                if (matrix[playerRow, playerColumn - 1] == 'B')
                {
                    playerColumn -= 1;
                    array[1] = true;
                }
                else
                {
                    matrix[playerRow, playerColumn] = '.';
                    matrix[playerRow, playerColumn - 1] = 'P';
                    playerColumn -= 1;
                }
            }
            return playerColumn;
        }

        private static int MoveUp(int playerRow, bool[] array, int playerColumn)
        {
            if (playerRow == 0)
            {
                array[0] = true;
            }
            else
            {
                if (matrix[playerRow - 1, playerColumn] == 'B')
                {
                    playerRow -= 1;
                    array[1] = true;
                }
                else
                {
                    matrix[playerRow, playerColumn] = '.';
                    matrix[playerRow - 1, playerColumn] = 'P';
                    playerRow -= 1;
                }               
            }
            return playerRow;
        }

        private static void AddNewBunnies(int rows, int columns, bool finishDead, bool finishAlive)
        {
            List<int[]> newBunnies = new List<int[]>();
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    if (matrix[j, k] == 'B')
                    {
                        int[] upIndex = new int[] { j - 1, k };
                        newBunnies.Add(upIndex);
                        int[] downIndex = new int[] { j + 1, k };
                        newBunnies.Add(downIndex);
                        int[] rightIndex = new int[] { j, k + 1 };
                        newBunnies.Add(rightIndex);
                        int[] leftIndex = new int[] { j, k - 1 };
                        newBunnies.Add(leftIndex);
                    }
                }
            }
            foreach (var newBunny in newBunnies)
            {
                bool rowIsValidate = newBunny[0] >= 0 && newBunny[0] < rows;
                bool colIsValidate = newBunny[1] >= 0 && newBunny[1] < columns;
                if (rowIsValidate && colIsValidate)
                {
                    if (matrix[newBunny[0], newBunny[1]] == '.')
                    {
                        matrix[newBunny[0], newBunny[1]] = 'B';
                    }
                    else if (matrix[newBunny[0], newBunny[1]] == 'P')
                    {
                        matrix[newBunny[0], newBunny[1]] = 'B';
                        finishDead = true;
                    }
                }
            }
        }

        private static void print(int rows, int columns, char[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}

using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,]matrix = new char[8,8];

            for (int i = 0; i < 8; i++)
            {
                var input = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
                for (int j = 0; j < 8; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                char figureType = input[0];
                int currentRow = int.Parse(input[1].ToString());
                int currentColumn = int.Parse(input[2].ToString());
                int desiredRow = int.Parse(input[4].ToString());
                int desiredColumn = int.Parse(input[5].ToString());
                if (matrix[currentRow, currentColumn] == figureType)
                {
                    if (figureType == 'K')
                    {
                        bool valid = ValidMoveKing(currentRow, currentColumn, desiredRow, desiredColumn);
                        if (valid)
                        {
                            bool secondValidation = SecondValidation(desiredRow, desiredColumn);
                            if (secondValidation)
                            {
                                matrix[desiredRow, desiredColumn] = 'K';
                                matrix[currentRow, currentColumn] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                        }
                    }
                    if (figureType == 'R')
                    {
                        bool valid = ValidMoveRook(currentRow, currentColumn, desiredRow, desiredColumn);
                        if (valid)
                        {
                            bool secondValidation = SecondValidation(desiredRow, desiredColumn);
                            if (secondValidation)
                            {
                                matrix[desiredRow, desiredColumn] = 'R';
                                matrix[currentRow, currentColumn] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                        }
                    }
                    if (figureType == 'P')
                    {
                        bool valid = ValidPawnMove(currentRow, currentColumn, desiredRow, desiredColumn);
                        if (valid)
                        {
                            bool secondValidation = SecondValidation(desiredRow, desiredColumn);
                            if (secondValidation)
                            {
                                matrix[desiredRow, desiredColumn] = 'P';
                                matrix[currentRow, currentColumn] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                        }
                    }
                    if (figureType == 'B')
                    {
                        bool valid = ValidBishopMove(currentRow, currentColumn, desiredRow, desiredColumn);
                        if (valid)
                        {
                            bool secondValidation = SecondValidation(desiredRow, desiredColumn);
                            if (secondValidation)
                            {
                                matrix[desiredRow, desiredColumn] = 'B';
                                matrix[currentRow, currentColumn] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                        }
                    }
                    if (figureType == 'Q')
                    {
                        if (ValidBishopMove(currentRow, currentColumn, desiredRow, desiredColumn) || ValidMoveRook(currentRow, currentColumn, desiredRow, desiredColumn))
                        {
                            bool secondValidation = SecondValidation(desiredRow, desiredColumn);
                            if (secondValidation)
                            {
                                matrix[desiredRow, desiredColumn] = 'Q';
                                matrix[currentRow, currentColumn] = 'x';
                            }
                            else
                            {
                                Console.WriteLine("Move go out of board!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no such a piece!");
                }
            }
        }
        private static bool SecondValidation(int desiredRow, int desiredColumn)
        {
            if (desiredRow < 8 && desiredColumn < 8 && desiredRow >= 0 && desiredColumn>=0)
            {
                return true;
            }
            return false;
        }

        private static bool ValidBishopMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            int diffRow = Math.Abs(desiredRow - currentRow);
            int diffColl = Math.Abs(desiredColumn - currentColumn);
            if (diffRow == diffColl && diffRow != 0)
            {
                return true;
            }
            return false;
        }

        private static bool ValidPawnMove(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            if (desiredRow == currentRow -1 && desiredColumn == currentColumn)
            {
                return true;
            }
                return false;           
        }

        private static bool ValidMoveRook(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            if ((desiredRow == currentRow && desiredColumn != currentColumn) || (desiredRow != currentRow && desiredColumn == currentColumn))
            {
                return true;
            }
            return false;
        }

        private static bool ValidMoveKing(int currentRow, int currentColumn, int desiredRow, int desiredColumn)
        {
            int diffRow = Math.Abs(desiredRow - currentRow);
            int diffColumn = Math.Abs(desiredColumn - currentColumn);
            if (diffRow >= 0 && diffRow <= 1 && diffColumn >= 0 && diffColumn <= 1)
            {
                if (diffRow == 0 && diffColumn == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}


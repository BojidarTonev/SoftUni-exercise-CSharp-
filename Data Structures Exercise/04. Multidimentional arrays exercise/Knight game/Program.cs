using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int removedKnihgts = 0;

            while (true)
            {
                var agresivniRicari = new List<Knight>();

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] == 'K')
                        {
                            int knightsAtacked = KnightAtackValidation(matrix, i, j, n);
                            Knight knight = new Knight() { row = i, column = j, atackCount = knightsAtacked };
                            agresivniRicari.Add(knight);
                        }
                    }
                }
                agresivniRicari = agresivniRicari.OrderByDescending(k => k.atackCount).ToList();
                if (agresivniRicari.First().atackCount == 0)
                {
                    Console.WriteLine(removedKnihgts);
                    break;
                }
                else
                {
                    matrix[agresivniRicari[0].row, agresivniRicari[0].column] = '0';
                    agresivniRicari.RemoveAt(0);

                    removedKnihgts++;
                }
            }


        }

        private static int KnightAtackValidation(char[,] matrix, int i, int j, int n)
        {
            int counter = 0;
            //up left moviement
            if (i - 2 >= 0 && j - 1 >= 0)
            {
                if (matrix[i - 2, j - 1] == 'K')
                {
                    counter++;
                }
            }
            //up right moviement
            if (i - 2 >= 0 && j + 1 < n)
            {
                if (matrix[i - 2, j + 1] == 'K')
                {
                    counter++;
                }
            }
            //right up moviement
            if (i - 1 >= 0 && j + 2 < n)
            {
                if (matrix[i - 1, j + 2] == 'K')
                {
                    counter++;
                }
            }
            //right down moviement
            if (i + 1 < n && j + 2 < n)
            {
                if (matrix[i + 1, j + 2] == 'K')
                {
                    counter++;
                }
            }
            //down  right moviement
            if (i + 2 < n && j + 1 < n)
            {
                if (matrix[i + 2, j + 1] == 'K')
                {
                    counter++;
                }
            }
            //down left moviement
            if (i + 2 < n && j - 1 >= 0)
            {
                if (matrix[i + 2, j - 1] == 'K')
                {
                    counter++;
                }
            }
            //left down moviement
            if (i + 1 < n && j - 2 >= 0)
            {
                if (matrix[i + 1, j - 2] == 'K')
                {
                    counter++;
                }
            }
            //left up moviement
            if (i - 1 >= 0 && j - 2 >= 0)
            {
                if (matrix[i - 1, j - 2] == 'K')
                {
                    counter++;
                }
            }
            return counter;
        }
    }

    public class Knight
    {
        public int row { get; set; }
        public int column { get; set; }
        public int atackCount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace String_matrix_roatation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            long bestLength = 0;
            long degrees = long.Parse(input[1]);
            List<string> allInput = new List<string>();
            bestLength = ProcessingInputData(bestLength, allInput);
            char[,] matrix = new char[allInput.Count, bestLength];
            EquivalentWords(allInput, bestLength);
            FillingMatrix(allInput, bestLength, matrix);
            long number = degrees / 90;
            List<long>degrees90 = new List<long>();
            List<long>degrees180 = new List<long>();
            List<long> degrees270 = new List<long>();
            List<long> degrees360 = new List<long>();


            long counter = 0;
            for (long i = 0; i <= 100; i++)
            {
                degrees360.Add(counter);
                counter++;
                degrees90.Add(counter);
                counter++;
                degrees180.Add(counter);
                counter++;
                degrees270.Add(counter);
                counter++;
            }

            if (degrees90.Contains(number))
            {
                char[,] newMatrix = new char[bestLength, allInput.Count];
                Rotation90(allInput, bestLength, newMatrix);
                Prlong90(bestLength, allInput, newMatrix);
            }
            if (degrees180.Contains(number))
            {
                char[,] newMatrix = new char[allInput.Count, bestLength];
                Rotation180(allInput, bestLength, newMatrix);
                Prlong180(allInput, bestLength, newMatrix);                
            }
            if (degrees270.Contains(number))
            {
                char[,] newMatrix = new char[bestLength, allInput.Count];
                Rotation270(allInput, bestLength, newMatrix);
                Prlong90(bestLength, allInput, newMatrix);
            }
            if (degrees360.Contains(number))
            {
                Prlong360(allInput, bestLength, matrix);
            }
        }

        private static void Prlong360(List<string> allInput, long bestLength, char[,] matrix)
        {
            for (long i = 0; i < allInput.Count; i++)
            {
                for (long j = 0; j < bestLength; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotation270(List<string>allInput, long bestLength, char[,]newMatrix)
        {
            List<string> copy = new List<string>(allInput);
            for (int i = 0; i < copy.Count; i++)
            {
                char[] word = copy[i].ToCharArray();
                Array.Reverse(word);
                copy[i] = new string(word);
            }
            long k = 0;
            while (copy.Count > 0)
            {
                for (int i = 0; i < bestLength; i++)
                {
                    string word = copy[i];
                    for (int j = 0; j < word.Length; j++)
                    {
                        newMatrix[j, k] = word[j];
                        i++;
                    }
                }
                copy.RemoveAt(0);
                k++;
            }
        }

        private static void Prlong180(List<string>allInput, long bestLength, char[,]newMatrix)
        {
            for (long i = 0; i < allInput.Count; i++)
            {
                for (long j = 0; j < bestLength; j++)
                {
                    Console.Write(newMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotation180(List<string>allInput, long bestLength, char[,]newMatrix)
        {
            List<string> copy = new List<string>(allInput);
            copy.Reverse();
            for (int i = 0; i < copy.Count; i++)
            {
                char[] word = copy[i].ToCharArray();
                Array.Reverse(word);
                copy[i] = new string(word);
            }
            for (int i = 0; i < allInput.Count; i++)
            {
                string word = copy[i];
                for (int j = 0; j < bestLength; j++)
                {
                    newMatrix[i, j] = word[j];
                }
            }
        }

        private static void Prlong90(long bestLength, List<string> allInput, char[,] newMatrix)
        {
            for (int i = 0; i < bestLength; i++)
            {
                for (int j = 0; j < allInput.Count; j++)
                {
                    Console.Write(newMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void Rotation90(List<string> allInput, long bestLength, char[,] newMatrix)
        {
            List<string> copy = new List<string>(allInput);
            copy.Reverse();
            long k = 0;
            while (copy.Count > 0)
            {
                for (int i = 0; i < bestLength; i++)
                {
                    string word = copy[i];
                    for (int j = 0; j < word.Length; j++)
                    {
                        newMatrix[j, k] = word[j];
                        i++;
                    }
                }
                copy.RemoveAt(0);
                k++;
            }
        }

        private static void EquivalentWords(List<string> allItems, long bestLength)
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if (allItems[i].Length < bestLength)
                {
                    long diff = bestLength - allItems[i].Length;
                    for (int j = 0; j < diff; j++)
                    {
                        allItems[i] += " ";
                    }
                }
            }
        }

        private static void FillingMatrix(List<string> allInput, long bestLength, char[,] matrix)
        {
            for (int i = 0; i < allInput.Count; i++)
            {
                string word = allInput[i];
                for (int j = 0; j < bestLength; j++)
                {
                    matrix[i, j] = word[j];
                }
            }
        }

        private static long ProcessingInputData(long bestLength, List<string> allInput)
        {
            while (true)
            {
                string matrixInput = Console.ReadLine();
                if (matrixInput == "END")
                {
                    break;
                }
                if (bestLength < matrixInput.Length)
                {
                    bestLength = matrixInput.Length;
                }
                allInput.Add(matrixInput);
            }
            return bestLength;
        }
    }
}


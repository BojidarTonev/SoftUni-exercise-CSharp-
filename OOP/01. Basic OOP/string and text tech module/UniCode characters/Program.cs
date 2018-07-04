using System;

namespace UniCode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            foreach (var letter in input)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:X}", value);
                Console.Write($"\\u{hexOutput.PadLeft(4, '0')}");
            }

            Console.WriteLine();
        }
    }
}

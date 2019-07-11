using System;
using System.Linq;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string name = firstInput[0] + " " + firstInput[1];
            string city = firstInput[2];
            string town = firstInput[3];
            var firstTuple = new Tuple<string, string, string>(name, city, town);
            Console.WriteLine(firstTuple.ToString());

            var secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string secondName = secondInput[0];
            int amount = int.Parse(secondInput[1]);
            bool drunk = false;
            string drunkness = secondInput[2];
            if (drunkness == "drunk")
            {
                drunk = true;
            }
            else
            {
                drunk = false;
            }
            var secondTuple = new Tuple<string, int, bool>(secondName, amount, drunk);
            Console.WriteLine(secondTuple.ToString());

            var thirdInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            string first = thirdInput[0];
            double second = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];
            var thirdTuple = new Tuple<string, double, string>(first, second, bankName);
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}

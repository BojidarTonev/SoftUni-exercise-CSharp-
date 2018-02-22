using System;
using System.Linq;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaInput = Console.ReadLine().Split(' ', StringSplitOptions.None).ToArray();
            string pizzaName = pizzaInput[1];
            Pizza pizza = null;
            try
            {
                pizza = new Pizza(pizzaName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            var doughInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string flourType = doughInput[1];
            string backingTechnique = doughInput[2];
            double grams = double.Parse(doughInput[3]);

            try
            {
                Dough dough = new Dough(flourType, backingTechnique, grams);
                pizza.Dough = dough;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string toppingType = tokens[1];
                double gram = double.Parse(tokens[2]);
                try
                {
                    Topping topping = new Topping(toppingType, gram);
                    pizza.AddTopping(topping);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            Console.WriteLine($"{pizza.Name} - {pizza.GetCalories:f2} Calories.");
        }
    }
}

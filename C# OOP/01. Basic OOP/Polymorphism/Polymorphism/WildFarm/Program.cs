using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal>animals = new List<Animal>();

            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (counter%2==0)
                {
                    if (tokens[0] == "Owl")
                    {
                        Owl owl = new Owl(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]), double.Parse(tokens[4]));
                        owl.ProduceSound();
                        animals.Add(owl);
                    }
                    else if (tokens[0] == "Hen")
                    {
                        Hen hen = new Hen(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]), double.Parse(tokens[4]));
                        hen.ProduceSound();
                        animals.Add(hen);
                    }
                    else if (tokens[0] == "Mouse")
                    {
                        Mouse mouse = new Mouse(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                        mouse.ProduceSound();
                        animals.Add(mouse);
                    }
                    else if (tokens[0] == "Dog")
                    {
                        Dog dog = new Dog(tokens[1], double.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                        dog.ProduceSound();
                        animals.Add(dog);
                   }
                    else if (tokens[0] == "Cat")
                    {
                        //
                    }
                    else if (tokens[0] == "Tiger")
                    {
                        //
                    }
                }
                else
                {
                    string typeOfFood = tokens[0];
                    int quantity = int.Parse(tokens[1]);
                    Food food = new Food(typeOfFood, quantity);
                    if (food.Type == "Vegetable")
                    {
                        if (animals.Last().GetType().Name == "Hen")
                        {
                            double growth = 0.35 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Mouse")
                        {
                            double growth = 0.10 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Cat")
                        {
                            double growth = 0.30 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}");
                        }
                    }

                    if (food.Type == "Fruit")
                    {
                        if (animals.Last().GetType().Name == "Hen")
                        {
                            double growth = 0.35 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Mouse")
                        {
                            double growth = 0.10 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}");
                        }
                    }

                    if (food.Type == "Meat")
                    {
                        if (animals.Last().GetType().Name == "Hen")
                        {
                            double growth = 0.35 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Cat")
                        {
                            double growth = 0.30 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Tiger")
                        {
                            double growth = 1.00 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Dog")
                        {
                            double growth = 0.40 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Owl")
                        {
                            double growth = 0.25 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}");
                        }
                    }

                    if (food.Type == "Seeds")
                    {
                        if (animals.Last().GetType().Name == "Hen")
                        {
                            double growth = 0.35 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else if (animals.Last().GetType().Name == "Mouse")
                        {
                            double growth = 0.10 * food.Quantity;
                            animals.Last().Weight += growth;
                        }
                        else
                        {
                            Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}");
                        }
                    }
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }
    }
}

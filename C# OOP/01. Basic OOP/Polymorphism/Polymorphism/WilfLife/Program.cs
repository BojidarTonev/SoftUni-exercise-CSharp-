using System;
using System.Collections.Generic;
using System.Linq;

namespace WilfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (counter % 2 == 0)
                {
                    AddingAnimal(tokens, animals);
                }
                else
                {
                    FeedingAnimals(tokens, animals);
                }
                counter++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static void FeedingAnimals(string[] tokens, List<Animal> animals)
        {
            Food food = new Food(tokens[0], int.Parse(tokens[1]));
            if (animals.Last().GetType().Name == "Mouse")
            {
                if (food.Type == "Vegetable" || food.Type == "Fruit")
                {
                    animals.Last().Weight += food.Quantity * 0.10;
                    animals.Last().FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}!");
                }
            }
            else if (animals.Last().GetType().Name == "Cat")
            {
                if (food.Type == "Vegetable" || food.Type == "Meat")
                {
                    animals.Last().Weight += food.Quantity * 0.30;
                    animals.Last().FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}!");
                }
            }

            else if (animals.Last().GetType().Name == "Hen")
            {
                animals.Last().Weight += food.Quantity * 0.35;
                animals.Last().FoodEaten += food.Quantity;
            }
            else if (animals.Last().GetType().Name == "Owl")
            {
                if (food.Type == "Meat")
                {
                    animals.Last().Weight += food.Quantity * 0.25;
                    animals.Last().FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}!");
                }
            }
            else if (animals.Last().GetType().Name == "Dog")
            {
                if (food.Type == "Meat")
                {
                    animals.Last().Weight += food.Quantity * 0.40;
                    animals.Last().FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}!");
                }
            }
            else if (animals.Last().GetType().Name == "Tiger")
            {
                if (food.Type == "Meat")
                {
                    animals.Last().Weight += food.Quantity * 1.00;
                    animals.Last().FoodEaten += food.Quantity;
                }
                else
                {
                    Console.WriteLine($"{animals.Last().GetType().Name} does not eat {food.Type}!");
                }
            }
        }

        private static void AddingAnimal(string[] tokens, List<Animal> animals)
        {
            if (tokens[0] == "Cat")
            {
                Cat cat = new Cat(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                cat.ProduceSound();
                animals.Add(cat);
            }
            if (tokens[0] == "Dog")
            {
                Dog dog = new Dog(tokens[1], double.Parse(tokens[2]), tokens[3]);
                dog.ProduceSound();
                animals.Add(dog);
            }
            if (tokens[0] == "Hen")
            {
                Hen hen = new Hen(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                hen.ProduceSound();
                animals.Add(hen);
            }
            if (tokens[0] == "Mouse")
            {
                Mouse mouse = new Mouse(tokens[1], double.Parse(tokens[2]), tokens[3]);
                mouse.ProduceSound();
                animals.Add(mouse);
            }
            if (tokens[0] == "Owl")
            {
                Owl owl = new Owl(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
                owl.ProduceSound();
                animals.Add(owl);
            }
            if (tokens[0] == "Tiger")
            {
                Tiger tiger = new Tiger(tokens[1], double.Parse(tokens[2]), tokens[3], tokens[4]);
                tiger.ProduceSound();
                animals.Add(tiger);
            }
        }
    }
}

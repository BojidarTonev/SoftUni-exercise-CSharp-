using System;
using System.Collections.Generic;
using System.Linq;

namespace MordersCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            int happines = 0;
            string[] food = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < food.Length; i++)
            {
                switch (food[i].ToLower())
                {
                    case "apple":
                        Apple apple = new Apple(food[i]);
                        happines += apple.happinessPoints;
                        break;
                    case "cram":
                        Cram cram = new Cram(food[i]);
                        happines += cram.happinessPoints;
                        break;
                    case "honeycake":
                        honeyCake honeyCake = new honeyCake(food[i]);
                        happines += honeyCake.happinessPoints;
                        break;
                    case "lembas":
                        Lembas lembas = new Lembas(food[i]);
                        happines += lembas.happinessPoints;
                        break;
                    case "melon":
                        Melon melon = new Melon(food[i]);
                        happines += melon.happinessPoints;
                        break;
                    case "mushrooms":
                        Mushrooms mushrooms = new Mushrooms(food[i]);
                        happines += mushrooms.happinessPoints;
                        break;
                    default:
                        Else elseFood = new Else(food[i]);
                        happines += elseFood.happinessPoints;
                        break;
                }
            }

            Console.WriteLine(happines);
            if (happines < -5)
            {
                Console.WriteLine("Angry");
            }
            if (happines >= -5 && happines <= 0)
            {
                Console.WriteLine("Sad");
            }

            if (happines >= 1 && happines <= 15)
            {
                Console.WriteLine("Happy");
            }

            if (happines > 15)
            {
                Console.WriteLine("JavaScript");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DefiningClassesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                new Car(model, fuelAmount, fuelConsumptionFor1km);              
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = tokens[1];
                int disiredDistance = int.Parse(tokens[2]);
                foreach (var car in Car.cars)
                {
                    if (car.Model == model)
                    {
                        Car.DriveTheWay(model, disiredDistance);
                        break;
                    }
                }
            }

            foreach (var car in Car.cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTravelled}");
            }
        }
    }
}

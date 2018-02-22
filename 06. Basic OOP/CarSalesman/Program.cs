using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            var engineList = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = input[0];
                int power = int.Parse(input[1]);

                if (input.Length == 3)
                {
                    if (Int32.TryParse(input[2], out int displacement))
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engineList.Add(engine);
                    }
                    else
                    {
                        string efficency = input[2];
                        Engine engine = new Engine(model, power, efficency);
                        engineList.Add(engine);
                    }
                }
                else if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficency = input[3];
                    Engine engine = new Engine(model, power, displacement, efficency);
                    engineList.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engineList.Add(engine);
                }
            }

            var carList = new List<Car>();
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var carsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carsInput[0];
                string engine = carsInput[1];
                if (carsInput.Length == 3)
                {
                    if (int.TryParse(carsInput[2], out int num))
                    {
                        //constructor with weight
                        string nn = num.ToString();
                        Car car = new Car(model, engine, nn);
                        carList.Add(car);
                    }
                    else
                    {
                        //constructor with color
                        string color = carsInput[2];
                        Car car = new Car(model, engine, color);
                        carList.Add(car);
                    }
                }
                else if (carsInput.Length == 4)
                {
                    //full constructor
                    string weight = carsInput[2];
                    string color = carsInput[3];
                    Car car = new Car(model, engine, weight, color);
                    carList.Add(car);
                }
                else
                {
                    //min constructor
                    Car car = new Car(model, engine);
                    carList.Add(car);
                }
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model}:");
                var engine = engineList.Where(x => x.Model.Equals(car.Engine)).First();
                Console.WriteLine($"  {engine.Model}:");
                Console.WriteLine($"    Power: {engine.Power}");
                Console.WriteLine($"    Displacement: {engine.Displacement}");
                Console.WriteLine($"    Efficiency: {engine.Efficency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}

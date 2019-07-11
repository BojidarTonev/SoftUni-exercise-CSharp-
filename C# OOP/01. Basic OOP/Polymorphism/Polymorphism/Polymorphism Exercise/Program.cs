using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace PolymorphismExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), int.Parse(carInput[3]));

            var truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), int.Parse(truckInput[3]));

            var busInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), int.Parse(busInput[3]));

            int n = int.Parse(Console.ReadLine());
            ProcessData(n, car, truck, bus);         

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static void ProcessData(int n, Vehicle car, Vehicle truck, Bus bus)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[1] == "Bus")
                {
                    if (input[0] == "DriveEmpty")
                    {
                        bus.DriveEmpty(double.Parse(input[2]));
                    }
                    if(input[0] == "Drive")
                    {
                        bus.DriveFull(double.Parse(input[2]));
                    }
                }

                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(double.Parse(input[2]));
                    }

                    if (input[1] == "Truck")
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                }

                if (input[0] == "Refuel")
                {
                    if (double.Parse(input[2]) <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                    }

                    else if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }

                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(input[2]));
                    }
                }
            }
        }
    }
}

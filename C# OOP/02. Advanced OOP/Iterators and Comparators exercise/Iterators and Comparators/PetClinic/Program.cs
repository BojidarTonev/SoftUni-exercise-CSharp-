using System;
using System.Linq;

namespace PetClinicc
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    ProcessingRawData(input, manager);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                               
            }
        }

        private static void ProcessingRawData(string[] input, Manager manager)
        {
            if (input[0] == "Add")
            {
                Console.WriteLine(manager.Add(input[1], input[2]));
            }
            else if (input[0] == "Release")
            {
                Console.WriteLine(manager.Release(input[1]));
            }
            else if (input[0] == "HasEmptyRooms")
            {
                Console.WriteLine(manager.HasEmptyRooms(input[1]));
            }
            else if (input[0] == "Create" && input[1] == "Pet")
            {
                manager.CreatePet(input[2], int.Parse(input[3]), input[4]);
            }
            else if (input[0] == "Create" && input[1] == "Clinic")
            {
                manager.CreateClinic(input[2], int.Parse(input[3]));
            }
            else if (input[0] == "Print" && input.Length == 2)
            {
                 Console.WriteLine(manager.PrintClinic(input[1]));
            }
            else if (input[0] == "Print" && input.Length == 3)
            {
                Console.WriteLine(manager.PrintSingle(input[1], int.Parse(input[2])));
            }
        }
    }
}

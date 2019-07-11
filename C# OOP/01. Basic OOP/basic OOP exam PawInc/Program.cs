using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PawInc
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLogic logic = new MainLogic();
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Paw Paw Pawah")
                {
                    break;
                }
                ProcessingRawData(logic, input);
            }
            Print(logic);          
        }

        private static void Print(MainLogic logic)
        {
            Console.WriteLine("Paw Incorporative Regular Statistics");
            Console.WriteLine($"Adoption Centers: {logic.adoptionCenters.Count}");
            Console.WriteLine($"Cleansing Centers: {logic.cleansingCenters.Count}");
            logic.adoptedAnimals = logic.adoptedAnimals.OrderBy(x => x).ToList();
            logic.cleansedAnimals = logic.cleansedAnimals.OrderBy(x => x).ToList();
            Console.Write($"Adopted Animals: ");
            if (logic.adoptedAnimals.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", logic.adoptedAnimals)}");
            }
            Console.Write($"Cleansed Animals: ");
            if (logic.cleansedAnimals.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", logic.cleansedAnimals)}");
            }
            Console.WriteLine($"Animals Awaiting Adoption: {logic.adoptionCenters.Sum(x=> x.Animals.Count)}");
            Console.WriteLine($"Animals Awaiting Cleansing: {logic.cleansingCenters.Sum(x => x.Animals.Count)}");           
        }

        private static void ProcessingRawData(MainLogic logic, string input)
        {
            var tokens = input.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            switch (tokens[0])
            {
                case "RegisterCleansingCenter":
                    logic.RegisterCleansingCenter(tokens[1]);
                    break;
                case "RegisterAdoptionCenter":
                    logic.RegisterAdoptionCenter(tokens[1]);
                    break;
                case "RegisterDog":
                    logic.RegisterDog(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                    break;
                case "RegisterCat":
                    logic.RegisterCat(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                    break;
                case "SendForCleansing":
                    logic.SendForCleansing(tokens[1], tokens[2]);
                    break;
                case "Cleanse":
                    logic.Cleanse(tokens[1]);
                    break;
                case "Adopt":
                    logic.Adopt(tokens[1]);
                    break;
            }
        }
    }
}

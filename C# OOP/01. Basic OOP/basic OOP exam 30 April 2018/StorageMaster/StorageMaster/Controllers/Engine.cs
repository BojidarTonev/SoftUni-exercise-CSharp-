using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StorageMaster.Controllers
{
    public class Engine
    {
        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                try
                {
                    CommandInterpreter(storageMaster, input);
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(InvalidOperationException))
                    {
                        Console.WriteLine($"Error: {e.Message}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {e.InnerException.Message}");
                    }
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }

        private void CommandInterpreter(StorageMaster storageMaster, string input)
        {
            var tokens = input.Split().ToArray();
            string command = tokens[0];
            string[] commandArgs = tokens.Skip(1).ToArray();

            switch (command)
            {
                case "AddProduct":
                    Console.WriteLine(storageMaster.AddProduct(commandArgs[0], double.Parse(commandArgs[1])));
                    break;
                case "RegisterStorage":
                    Console.WriteLine(storageMaster.RegisterStorage(commandArgs[0], commandArgs[1]));
                    break;
                case "SelectVehicle":
                    Console.WriteLine(storageMaster.SelectVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "LoadVehicle":
                    Console.WriteLine(storageMaster.LoadVehicle(commandArgs));
                    break;
                case "SendVehicleTo":
                    Console.WriteLine(storageMaster.SendVehicleTo(commandArgs[0], int.Parse(commandArgs[1]), commandArgs[2]));
                    break;
                case "UnloadVehicle":
                    Console.WriteLine(storageMaster.UnloadVehicle(commandArgs[0], int.Parse(commandArgs[1])));
                    break;
                case "GetStorageStatus":
                    Console.WriteLine(storageMaster.GetStorageStatus(commandArgs[0]));
                    break;
                default:
                    return;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


public class CommandInterpreter
{
    private ICustomList<string> customList;

    public CommandInterpreter(ICustomList<string> list)
    {
        this.customList = list;
    }

    public void Execute()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            switch (tokens[0])
            {
                case "Add":
                    customList.Add(tokens[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(tokens[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(tokens[1]));                   
                    break;
                case "Swap":
                    customList.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(tokens[1]));                    
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());                 
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());                   
                    break;
                case "Print":
                    customList.Print();
                    break;
                case "Sort":
                    customList.Sort();
                    break;
            }
        }
    }
}


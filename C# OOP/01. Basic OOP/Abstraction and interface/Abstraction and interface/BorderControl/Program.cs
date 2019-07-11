using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthday> result = new List<IBirthday>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length == 5)
                {
                    string name = tokens[1];
                    string birthDay = tokens[4];
                    try
                    {
                        IBirthday person = new Citizen(name, birthDay);
                        result.Add(person);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (tokens.Length == 3)
                {
                    if (tokens[0].ToLower() == "pet")
                    {
                        string name = tokens[1];
                        string birthDay = tokens[2];
                        try
                        {
                            IBirthday pet = new Pet(name, birthDay);
                            result.Add(pet);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

            string year = Console.ReadLine();
            foreach (var thing in result)
            {
                if (thing.birthDate.EndsWith(year))
                {
                    Console.WriteLine(thing.birthDate);
                }
            }
        }
    }
}

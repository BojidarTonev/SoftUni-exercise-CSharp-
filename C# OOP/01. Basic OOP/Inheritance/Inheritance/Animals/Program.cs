using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
           

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }

                try
                {
                    var tokens = Console.ReadLine().Split();

                   var animal = CreatingAnimal(input, tokens);

                    Console.WriteLine(animal);
                  


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }               
            }
                
        }

        

        private static object CreatingAnimal(string input, string[] tokens)
        {
          
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string gender = tokens[2];

            switch (input)
            {
                case "Cat":
                    return new Cat(name, age, gender);          
                case "Dog":
                    return new Dog(name, age, gender);
                case "Frog":
                    return new Frog(name, age, gender);
                case "Tomcat":
                    return new Tomcat(name, age, gender);
                case "Kitten":
                    return new Kitten(name, age, gender);
                default:
                    throw new ArgumentException("Invalid input!");
            }
          
        }            

    }
}

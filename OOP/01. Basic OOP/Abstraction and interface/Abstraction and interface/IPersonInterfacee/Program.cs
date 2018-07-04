using System;

namespace IPersonInterfacee
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                string id = Console.ReadLine();
                string birthDate = Console.ReadLine();

                IIdentifiable person = new Citizen(name, age, id, birthDate);
                IBirthable person1 = new Citizen(name, age, id, birthDate);

                Console.WriteLine(person.Id);
                Console.WriteLine(person1.Birthdate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}

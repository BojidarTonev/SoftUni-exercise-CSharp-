using System;

namespace Ferrarrrii
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            try
            {
                ICar ferari = new Ferrari(name);
                Console.WriteLine(ferari);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

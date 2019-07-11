using System;
using System.Linq;

namespace Telephonyy
{
    class Program
    {
        static void Main(string[] args)
        {
            var telephoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            var webSites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            Smartphone smartphone = new Smartphone();

            for (int i = 0; i < telephoneNumbers.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.Dialnumber(telephoneNumbers[i]));                  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            for (int i = 0; i < webSites.Length; i++)
            {
                try
                {
                    Console.WriteLine(smartphone.BrowseInternet(webSites[i]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

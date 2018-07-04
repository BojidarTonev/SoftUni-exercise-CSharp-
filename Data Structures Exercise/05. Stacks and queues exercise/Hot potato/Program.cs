using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hot_potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            Queue<string> queu = new Queue<string>(input);

            while (queu.Count > 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    queu.Enqueue(queu.Dequeue());
                }
                Console.WriteLine($"Removed {queu.Dequeue()}");
            }
            Console.WriteLine($"Last is {queu.Dequeue()}");
        }
    }
}

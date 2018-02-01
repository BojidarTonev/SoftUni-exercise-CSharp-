using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(0);
            queue.Enqueue(1);
            for (int i = 0; i <= n-1; i++)
            {
                long first = queue.Dequeue();
                long second = queue.Peek();
                long sum = first + second;
                queue.Enqueue(sum);
            }
            Console.WriteLine(queue.Dequeue());
        }
    }
}

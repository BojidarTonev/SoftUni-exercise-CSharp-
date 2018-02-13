using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_cSharp_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int shotsFired = 0;
            int iterations = 0;

            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGun = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var locksInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int valueOfIntelligece = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            while (true)
            {
                if (bullets.Count > 0)
                {
                    if (iterations >= sizeOfGun)
                    {
                        Console.WriteLine("Reloading!");
                        iterations = 0;
                    }
                }              
                if (locks.Count == 0 || bullets.Count == 0)
                {
                    break;
                }
                iterations++;
                shotsFired++;
                int bullet = bullets.Pop();
                int locck = locks.Peek();
                if (bullet<=locck)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
            if (locks.Count> 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = 0;
                int moneSpentOnBullets = shotsFired * bulletPrice;
                moneyEarned = valueOfIntelligece - moneSpentOnBullets;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}

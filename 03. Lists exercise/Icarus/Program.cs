using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] planes = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());
            int damage = 1;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Supernova")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string direction = tokens[0];
                    int moves = int.Parse(tokens[1]);

                    if (direction == "right")
                    {
                        while (moves>0)
                        {
                            index += 1;
                            if (index<planes.Length)
                            {
                                planes[index] -= damage;
                            }
                            else
                            {
                                damage++;
                                index = 0;
                                planes[index] -= damage;
                            }
                            moves--;
                        }
                    }
                    if (direction == "left")
                    {
                        while (moves>0)
                        {
                            index -= 1;
                            if (index>= 0)
                            {
                                planes[index] -= damage;
                            }
                            else
                            {
                                damage++;
                                index = planes.Length - 1;
                                planes[index] -= damage;
                            }
                            moves--;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", planes));
        }
    }
}


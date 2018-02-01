using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_thread
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "3:1")
                {
                    break;
                }
                else
                {
                    string[] tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string command = tokens[0];
                    if (command == "merge")
                    {
                        int startIndex = int.Parse(tokens[1]);
                        if (startIndex < 0)
                        {
                            startIndex = 0;
                        }
                        int endIndex = int.Parse(tokens[2]);
                        if (endIndex > items.Count)
                        {
                            endIndex = items.Count;
                        }

                        string str = "";
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            str += items[i];
                        }
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            items.Remove(items[startIndex]);
                        }
                        items.Insert(startIndex, str);
                    }
                    else if (command == "divide")
                    {
                        int index = int.Parse(tokens[1]);
                        int partitions = int.Parse(tokens[2]);
                        int lengthOfPart = items[index].Length / partitions;
                        string str1 = "";
                        char chr1 = '/';

                        if (items[index].Length%2==0)
                        {
                            for (int i = 0; i < partitions; i++)
                            {
                                str1 += items[index].Substring(i, lengthOfPart);
                            }
                            items.RemoveAt(index);
                            items.Insert(index, str1);
                        }
                        else
                        {
                            chr1 = items[index].Last();
                            items[index].Remove(items[index].Last());

                            for (int i = 0; i < partitions; i++)
                            {
                                str1 += items[index].Substring(i, lengthOfPart);
                                str1 += " ";
                            }
                            str1 += chr1;
                            items.RemoveAt(index);
                            items.Insert(index, str1);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", items));
        }
    }
}

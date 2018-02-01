using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace camera_view
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> result = new List<char>();

            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int skipElements = array[0];
            int takeElement = array[1];

            char[] text = Console.ReadLine().ToArray();

        }
    }
}

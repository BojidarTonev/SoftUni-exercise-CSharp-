using System;

namespace BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string autor = Console.ReadLine();
                string title = Console.ReadLine();
                decimal price = decimal.Parse(Console.ReadLine());

                Book book = new Book(autor, title, price);
                GoldenEditionBook goldenBook = new GoldenEditionBook(autor, title, price);

                Console.WriteLine(book);
                Console.WriteLine(goldenBook);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

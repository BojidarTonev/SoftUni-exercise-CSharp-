using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShop.Data;
using BookShop.Models;

namespace BookShop
{
    public class StartUp
    {
        public static void Main()
        {
        }

        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            var restriction = (AgeRestriction)Enum.Parse(typeof(AgeRestriction), command, true);

            var bookTitles = db.Books
                .Where(b => b.AgeRestriction == restriction)
                .Select(b => b.Title)
                .OrderBy(b => b);

            string result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByPrice(BookShopContext db)
        {
            var books = db.Books
                .Where(b => b.Price > 40m)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - {b.Price:f2}");

            var result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {
            var books = db.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            string result = string.Join(Environment.NewLine, books);
            return result;
        }
        
        public static string GetBooksByCategory(BookShopContext db, string command)
        {
            var categories = command
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var books = db.Books
                .Where(b => b.BookCategories.Select(bc => bc.Category.Name.ToLower()).Intersect(categories).Any())
                .Select(b => b.Title)
                .OrderBy(b => b);

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string date)
        {
            var books = db.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", null))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType:G} - ${b.Price:f2}");

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext db, string input)
        {
            var authors = db.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}");

            string result = string.Join(Environment.NewLine, authors);
            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext db, string input)
        {
            var books = db.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b);

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static string GetBooksByAuthor(BookShopContext db, string input)
        {
            var books = db.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})");

            string result = string.Join(Environment.NewLine, books);
            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksWihtTitleLongerThan = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return booksWihtTitleLongerThan;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            string[] authorsWithBooksCount = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    CopiesCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.CopiesCount)
                .Select(a => $"{a.Name} - {a.CopiesCount}")
                .ToArray();

            string result = string.Join(Environment.NewLine, authorsWithBooksCount);
            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            string[] profitsByCategories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName)
                .Select(c => $"{c.CategoryName} ${c.Profit:F2}")
                .ToArray();

            string result = string.Join(Environment.NewLine, profitsByCategories);
            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoriestWithThreeMostRecentBooks = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksCount = c.CategoryBooks.Sum(bc => bc.Book.BookId),
                    Books = c.CategoryBooks.Select(bc => bc.Book).OrderByDescending(b => b.ReleaseDate).Take(3)
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var cat in categoriestWithThreeMostRecentBooks)
            {
                sb.AppendLine($"--{cat.CategoryName}");

                foreach (Book book in cat.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            const int ReleaseDate = 2010;
            const decimal IncreaseValue = 5;

            List<Book> booksWhichPriceWillBeIncreased = context.Books
                .Where(b => b.ReleaseDate.Value.Year < ReleaseDate)
                .ToList();

            booksWhichPriceWillBeIncreased.ForEach(b => b.Price += IncreaseValue);

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            const int CopiesHighValue = 4200;

            Book[] booksToBeRemoved = context.Books
                .Where(b => b.Copies < CopiesHighValue)
                .ToArray();

            int booksToBeRemovedCount = booksToBeRemoved.Length;

            context.Books.RemoveRange(booksToBeRemoved);
            context.SaveChanges();

            return booksToBeRemovedCount;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string autor;
    private string title;
    private decimal price;

    public Book()
    {
        this.Autor = autor;
        this.Price = price;
        this.Title = title;
    }

    public Book(string autor, string title, decimal price)
    {
        this.Autor = autor;
        this.Title = title;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }


    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
               throw  new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }


    public string Autor
    {
        get { return autor; }
        set
        {
            string[] names = value.Split();
            if (names.Length > 1 && Char.IsDigit(names[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            autor = value;
        }
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name);
        sb.Append("Title: ").AppendLine(this.Title);
        sb.Append("Author: ").AppendLine(this.Autor);
        sb.Append("Price: ").AppendLine($"{this.Price:f2}");

        return sb.ToString();
    }

}


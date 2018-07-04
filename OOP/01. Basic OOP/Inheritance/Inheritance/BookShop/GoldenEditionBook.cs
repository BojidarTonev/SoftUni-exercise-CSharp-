using System;
using System.Collections.Generic;
using System.Text;


public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string autor, string title, decimal price)
        : base(autor, title, price)
    {
    }

    public override decimal Price => base.Price * (decimal) 1.3;
}


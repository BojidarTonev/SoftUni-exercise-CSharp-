using System;
using System.Collections.Generic;
using System.Text;


class Smartphone : Functionality
{
    public string BrowseInternet(string url)
    {
        foreach (var c in url)
        {
            if (Char.IsDigit(c))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }
        return $"Browsing: {url}!";
    }

    public string Dialnumber(string number)
    {
        foreach (var c in number)
        {
            if (!Char.IsDigit(c))
            {
                throw new ArgumentException("Invalid number!");
            }
        }
        return $"Calling... {number}";
    }
}


using System;
using System.Collections.Generic;
using System.Text;


class AddCollection : IAddCollection
{
    private int counter = 0;
    public List<string> list { get; }
    public void Add(string input)
    {
        Console.Write(counter + " ");
        list.Add(input);
        counter++;
    }

    public AddCollection()
    {
        this.list = new List<string>();
    }
}


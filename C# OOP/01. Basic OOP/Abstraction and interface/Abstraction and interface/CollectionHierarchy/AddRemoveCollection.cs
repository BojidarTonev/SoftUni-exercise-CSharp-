using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class AddRemoveCollection : IAddRemoveCollection
{
    public List<string> list { get; }
    public void Add(string input)
    {
        Console.Write(0 + " ");
        list.Insert(0, input);
    }

    public void Remove()
    {
        if (list.Count > 0)
        {
            string last = list.Last();
            list.Remove(last);
            Console.Write($"{last} ");
        }
    }



    public AddRemoveCollection()
    {
        this.list = new List<string>();
    }
}


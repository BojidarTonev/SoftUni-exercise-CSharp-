using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;


class MyList : IMyList
{
    public List<string> list { get; }
    public int used { get; }

    public MyList()
    {
        this.list = new List<string>();
        this.used = list.Count;
    }

    public void Add(string input)
    {
        Console.Write(0 + " ");
        list.Insert(0, input);
    }

    public void Remove()
    {
        if (list.Count > 0)
        {
            string last = list.First();
            list.Remove(last);
            Console.Write($"{last} ");
        }
    }
}


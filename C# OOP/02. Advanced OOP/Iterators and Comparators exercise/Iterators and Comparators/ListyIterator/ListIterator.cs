using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ListIterator<T> : IEnumerable<T>
{
    private readonly List<T> internalList;
    public const int firstPosition = 0;
    private int pointer;

    public ListIterator()
    {
        this.pointer = firstPosition;
        this.internalList = new List<T>();
    }

    public ListIterator(IEnumerable<T> collection)
    {
        this.internalList = new List<T>(collection);
        this.pointer = firstPosition;
    }

    public bool Move()
    {
        if (this.pointer + 1 < this.internalList.Count)
        {
            this.pointer++;
            return true;
        }
        return false;
    }

    public bool HasNext() => this.pointer + 1 < this.internalList.Count;

    public void Print()
    {
        if (this.internalList.Count == 0)
        {
            Console.WriteLine("Invalid Operation!");
        }
        else 
        {
            Console.WriteLine($"{this.internalList[this.pointer]}");
        }
    }

    public void PrintAll()
    {
        var sb = new StringBuilder();
        foreach (var item in internalList)
        {
            sb.Append($"{item} ");
        }

        sb.ToString().TrimEnd();
        Console.WriteLine(sb);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.internalList.Count; i++)
        {
            yield return this.internalList[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


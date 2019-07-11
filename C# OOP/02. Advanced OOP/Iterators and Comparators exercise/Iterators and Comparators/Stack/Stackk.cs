using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Stack = System.Collections.Stack;


public class Stackk<T> : IEnumerable<T>
{
    private Stack<T> internalStack;

    public Stackk()
    {
        this.internalStack = new Stack<T>();
    }

    public T Pop()
    {
        if (internalStack.Count == 0)
        {
            throw new ArgumentException("No elements");
        }

        return internalStack.Pop();
    }

    public void Push(T[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            internalStack.Push(args[i]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        List<T> temp = new List<T>(this.internalStack);
        for (int i = 0; i < temp.Count; i++)
        {
            yield return temp[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


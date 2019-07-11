using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T> : ICustomList<T>
where T : IComparable<T>
{
    private IList<T> items;

    public CustomList()
    {
        items = new List<T>();
    }

    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        var element = items[index];
        items.Remove(element);

        return element;
    }

    public bool Contains(T element)
    {
        if (items.Contains(element))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Swap(int index1, int index2)
    {
        var firstElement = items[index1];
        var secondElement = items[index2];

        items[index1] = secondElement;
        items[index2] = firstElement;
    }

    public int CountGreaterThan(T element)
    {
        int count = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (element.CompareTo(items[i]) < 0)
            {
                count++;
            }
        }

        return count;
    }

    public T Max()
    {
        T maxElement = items.Max();

        return maxElement;
    }

    public T Min()
    {
        T minElement = items.Min();

        return minElement;
    }

    public void Print()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void Sort()
    {
        items = items.OrderBy(x => x).ToList();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

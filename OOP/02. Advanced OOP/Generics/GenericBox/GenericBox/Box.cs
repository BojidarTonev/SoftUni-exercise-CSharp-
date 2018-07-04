using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Box<T>
where T : IComparable
{
    private List<T> items;
   

    public Box()
    {
        this.items = new List<T>();
    }

    public List<T> Items
    {
        get { return items; }
        private set { items = value; }
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public int CompareTo(T item)
    {
        int greaterItems = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (item.CompareTo(items[i]) < 0 )
            {
                greaterItems++;
            }
        }

        return greaterItems;
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var fitstItem = items[firstIndex];
        var secondItem = items[secondIndex];
        items[firstIndex] = secondItem;
        items[secondIndex] = fitstItem;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in items)
        {
            sb.AppendLine($"{item.GetType().FullName}: {item}");
        }

        return sb.ToString().TrimEnd();
    }
}


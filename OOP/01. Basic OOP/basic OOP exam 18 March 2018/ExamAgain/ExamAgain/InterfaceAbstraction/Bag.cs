using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamAgain.InterfaceAbstraction;


public abstract class Bag
{
    private int capacity;
    private int load;
    private IReadOnlyCollection<Item> items;

    public Bag(int capacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>().AsReadOnly();
    }

    public IReadOnlyCollection<Item> Items
    {
        get { return items; }
        protected set { items = value; }
    }

    public int Load
    {
        get { return load; }
        protected set { load = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        protected set { capacity = value; }
    }

    public void AddItem(Item item)
    {
        this.Load = this.Items.Sum(x => x.Weight);
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException(ExceptionMesseges.BagIsFull);
        }

        List<Item> newItems = this.Items.ToList();
        newItems.Add(item);
        this.Items = newItems;
    }

    public Item GetItem(string name)
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException(ExceptionMesseges.BasIsEmpty);
        }
        if (this.Items.FirstOrDefault(i => i.GetType().Name == name) == null)
        {
            throw new ArgumentException($"Parameter Error: No item with name {name} in bag!");
        }

        Item item = this.Items.First(i => i.GetType().ToString() == name);
        List<Item> newItems = this.Items.ToList();
        newItems.Remove(item);
        this.Items = newItems;

        return item;
    }

}


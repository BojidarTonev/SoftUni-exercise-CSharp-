using System;
using System.Collections.Generic;
using System.Text;


public class Database
{
    private const int defaultCapacity = 16;
    private int[] internalArray;
    private int index;

    public Database()
    {
        this.internalArray = new int[defaultCapacity];
        this.index = 0;
    }

    public Database(params int[] values)
        :this()
    {
        this.InitializeArray(values);
        this.index = values.Length - 1;
    }

    private void InitializeArray(int[] values)
    {
        if (values.Length >= defaultCapacity)
        {
            throw new InvalidOperationException("Length is bigger than the internal array.");
        }

        for (int i = 0; i < values.Length; i++)
        {
            this.internalArray[i] = values[i];
        }

        this.index = values.Length;
    }

    public void Add(int numberToAdd)
    {
        if (index >= defaultCapacity)
        {
            throw new InvalidOperationException("Array is full!");
        }
        this.internalArray[index] = numberToAdd;
        this.index++;
    }

    public void Remove()
    {
        if (index == 0)
        {
            throw new InvalidOperationException("There are no elements in the array.");
        }

        this.internalArray[index] = default(int);
        index--;
    }

    public int[] Fetch()
    {
        int[] returendArray = new int[defaultCapacity];
        Array.Copy(this.internalArray, returendArray, defaultCapacity);
        return returendArray;
    }
}


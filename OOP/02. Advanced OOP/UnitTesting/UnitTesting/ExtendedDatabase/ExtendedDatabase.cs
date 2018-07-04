using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ExtendedDatabase
{
    private const int defaultCapacity = 16;
    private Person[] internalArray;
    private int index;

    public ExtendedDatabase()
    {
        this.internalArray = new Person[defaultCapacity];
        this.index = 0;
    }

    public ExtendedDatabase(params Person[] values)
        : this()
    {
        this.InitializeArray(values);
        this.index = values.Length - 1;
    }

    private void InitializeArray(params Person[] values)
    {
        if (values.Length >= defaultCapacity)
        {
            throw new InvalidOperationException("Length is bigger than the internal array.");
        }

        for (int i = 0; i < values.Length; i++)
        {
            this.internalArray[i] = values[i];
        }
    }

    public void Add(Person personToAdd)
    {
        if (index >= defaultCapacity)
        {
            throw new InvalidOperationException("Array is full!");
        }

        if (this.internalArray.Any(p => p != null && p.Id == personToAdd.Id))
        {
            throw new InvalidOperationException("A person with that id has already been added.");
        }

        if (this.internalArray.Any(p => p != null && p.Name == personToAdd.Name))
        {
            throw new InvalidOperationException("A person with that name has already been added.");
        }
        this.internalArray[index] = personToAdd;
        this.index++;
    }

    public void Remove()
    {
        if (index == 0)
        {
            throw new InvalidOperationException("There are no elements in the array.");
        }

        this.internalArray[index] = null;
        index--;
    }

    public Person FindByUsername(string username)
    {
        if (internalArray.FirstOrDefault(p => p.Name == username) == null)
        {
            throw new ArgumentNullException("No one with a name like that exists.");
        }

        if (username == null)
        {
            throw new ArgumentNullException("Invalid input!");
        }

        return internalArray.First(p => p.Name == username);
    }

    public Person FindById(int searchedId)
    {
        if (searchedId < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid input!");
        }
        if (internalArray.First(p => p.Id == searchedId) == null)
        {
            throw new InvalidOperationException("No person with that id found.");
        }

        return internalArray.First(p => p.Id == searchedId);
    }
}


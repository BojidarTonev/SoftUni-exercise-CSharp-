using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class HashSorter : IEnumerable<Person>
{
    private readonly HashSet<Person> internalSet;

    public HashSorter()
    {
        this.internalSet = new HashSet<Person>();
    }

    public HashSorter(IEnumerable<Person> collection)
    {
        this.internalSet = new HashSet<Person>(collection);
    }

    public IEnumerator<Person> GetEnumerator()
    {
            
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override int GetHashCode()
    {
        return this.internalSet.GetHashCode() * 17;
    }
}


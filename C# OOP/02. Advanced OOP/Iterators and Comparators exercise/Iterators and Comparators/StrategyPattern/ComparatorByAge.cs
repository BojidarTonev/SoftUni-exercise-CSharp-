using System;
using System.Collections.Generic;
using System.Text;


public class ComparatorByAge : IComparer<Person>
{
    public readonly List<Person> internalList;

    public ComparatorByAge(List<Person> internalList)
    {
        this.internalList = internalList;
    }
    
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);

        return result;
    }
}


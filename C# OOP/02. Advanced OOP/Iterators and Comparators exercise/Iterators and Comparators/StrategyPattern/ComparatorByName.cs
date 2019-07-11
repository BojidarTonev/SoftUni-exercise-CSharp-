using System;
using System.Collections.Generic;
using System.Text;


public class ComparatorByName : IComparer<Person>
{
    public readonly List<Person> internalList;

    public ComparatorByName(List<Person> internalList)
    {
        this.internalList = internalList;
    }

    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            string firstChar = x.Name[0].ToString().ToLower();
            string secondChar = y.Name[0].ToString().ToLower();
            result = firstChar.CompareTo(secondChar);
        }

        return result;
    }
}


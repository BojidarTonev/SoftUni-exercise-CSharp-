using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string Name, int Age, string Town)
    {
        this.name = Name;
        this.town = Town;
        this.age = Age; 
    }

    public string Town
    {
        get { return town; }
        private set { town = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int CompareTo(Person other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }
        if (result == 0)
        {
            result = this.Town.CompareTo(other.Town);
        }

        return result;
    }
}


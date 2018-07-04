using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
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
        return result;
    }

    public override bool Equals(Object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
 
        Person p = (Person)obj;
        return (this.Age == p.Age) && (this.Name == p.Name);

    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() * 100 + this.Age;
    }
}


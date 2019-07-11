using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthDate;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string Birthdate { get; private set; }

    public override string ToString()
    {
        return $"{this.Name}\n{this.Age}";
    }
}

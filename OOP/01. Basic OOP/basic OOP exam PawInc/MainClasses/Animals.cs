using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;


public abstract class Animals
{
    private string name;
    private int age;
    private bool clean;
    public string sendBackTo;
    
    public Animals(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.clean = false;
    }

    public bool Clean
    {
        get { return clean; }
        set { clean = value; }
    }

    public int Age
    {
        get { return age; }
        protected set { age = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

}


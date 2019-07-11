using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Centers
{
    private string name;
    private List<Animals> animals;
    public string type;

    public Centers(string name)
    {
        this.Name = name;
        this.Animals = new List<Animals>();
    }

    public List<Animals> Animals
    {
        get { return animals; }
        protected set { animals = value; }
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

}


using System;
using System.Collections.Generic;
using System.Text;


public class Trainer
{
    private List<Pokemon> pokemons = new List<Pokemon>();

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }


    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int numberOfBadges;

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    public Trainer(string name)
    {
        this.Name = name;
        this.NumberOfBadges = 0;
    }
}


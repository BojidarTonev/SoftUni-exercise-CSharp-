using System;
using System.Collections.Generic;
using System.Text;


public abstract class Gem : IGem, IGemClarity
{
    protected Gem(int strength, int agility, int vitality, GemEnums clarity)
    {
        this.Clarity = clarity;
        this.Strength = strength + (int) Clarity;
        this.Agility = agility + (int) Clarity;
        this.Vitality = vitality + (int) Clarity;
        this.Clarity = clarity + (int) Clarity;
    }
    public int Strength { get; }

    public int Agility { get; }

    public int Vitality { get; }

    public GemEnums Clarity { get; }
}


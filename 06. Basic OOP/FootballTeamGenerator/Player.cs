using System;
using System.Collections.Generic;
using System.Text;


class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    private int Shooting
    {
        get { return shooting; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }


    private int Passing
    {
        get { return passing; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }


    private int Dribble
    {
        get { return dribble; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }


    private int Sprint
    {
        get { return sprint; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }


    private int Endurance
    {
        get { return endurance; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }
            endurance = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public Player(int shooting, int passing, int dribble, int sprint, int endurance, string name)
    {
        this.Shooting = shooting;
        this.Passing = passing;
        this.Dribble = dribble;
        this.Sprint = sprint;
        this.Endurance = endurance;
        this.Name = name;
    }

    public double AverageSkill()
    {
        return (Shooting + Passing + Dribble + Sprint + Endurance) / 5.00;
    }
}


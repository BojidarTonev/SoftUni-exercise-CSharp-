using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Dog:Animals
{
    private int learnedCommands;

    public Dog(string name, int age, int loyalty) 
        : base(name, age)
    {
        this.LearnedCommands = loyalty;
    }

    public int LearnedCommands
    {
        get { return learnedCommands; }
        protected set { learnedCommands = value; }
    }

}


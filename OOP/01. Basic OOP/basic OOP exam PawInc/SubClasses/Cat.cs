using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Cat:Animals
{
    private int intelligenceCoefficent;

    public Cat(string name, int age, int intelligenceCoefficent) 
        : base(name, age)
    {
        this.intelligenceCoefficent = intelligenceCoefficent;
    }

    public int IntelligenceCoefficent
    {
        get { return intelligenceCoefficent; }
        protected set { intelligenceCoefficent = value; }
    }

}


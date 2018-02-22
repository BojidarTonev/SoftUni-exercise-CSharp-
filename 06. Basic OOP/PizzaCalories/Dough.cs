using System;
using System.Collections.Generic;
using System.Text;

class Dough
{
    private string flourType;

    public string FlourType
    {
        get { return flourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {          
            bakingTechnique = value;
        }
    }

    private double weightInGrams;

    public double WeightInGrams
    {
        get { return weightInGrams; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weightInGrams = value;
        }
    }

    private double modifierFlour;

    private double modifierBaking;


    public Dough(string flourType, string bakigTechnique, double grams)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakigTechnique;
        this.WeightInGrams = grams;
        if (flourType.ToLower() == "white")
        {
            this.modifierFlour = 1.5;
        }

        if (flourType.ToLower() == "wholegrain")
        {
            this.modifierFlour = 1.0;
        }

        if (bakingTechnique.ToLower() == "chewy")
        {
            this.modifierBaking = 1.1;
        }

        if (bakingTechnique.ToLower() == "homemade")
        {
            this.modifierBaking = 1.0;
        }

        if (bakingTechnique.ToLower() == "crispy")
        {
            this.modifierBaking = 0.9;
        }
    }

    private double CalculateCalories(double modifierBaking, double modifierTechnique, double grams)
    {
        double result = (2 * grams) * modifierBaking * modifierTechnique;
        return result;
    }

    public double GetCalories
    {
        get
        {
            return this.CalculateCalories(modifierBaking, modifierFlour, WeightInGrams);
        }
    }
}


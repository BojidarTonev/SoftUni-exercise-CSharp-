using System;
using System.Collections.Generic;
using System.Text;


public class Track
{
    private int lapsNumber;
    private double length;
    public int currentLap;

    public Track(int lapsNumber, double length)
    {
        this.Length = length;
        this.LapsNumber = lapsNumber;
        this.currentLap = 0;
    }

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public int LapsNumber
    {
        get { return lapsNumber; }
        set { lapsNumber = value; }
    }

}


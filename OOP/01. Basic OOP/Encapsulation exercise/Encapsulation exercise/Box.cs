using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    private double height;

    public double Height
    {
        get { return height; }
        set
        { height = value; }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public void Volume()
    {
        double volume = length * width * height;
        Console.WriteLine($"Volume - {volume:f2}");
    }

    public void LiteralSurface()
    {
        double result = 2 * length * height + 2 * width * height;
        Console.WriteLine($"Lateral Surface Area - {result:f2}");
    }

    public void SurfaceArea()
    {
        double result = 2 * length * width + 2 * length * height + 2 * width * height;
        Console.WriteLine($"Surface Area - {result:f2}");
    }
}


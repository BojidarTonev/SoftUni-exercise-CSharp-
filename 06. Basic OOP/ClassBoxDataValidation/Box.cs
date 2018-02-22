using System;
using System.Collections.Generic;
using System.Text;


class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw  new ArgumentException("Height cannot be zero or negative.");
            }          
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
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


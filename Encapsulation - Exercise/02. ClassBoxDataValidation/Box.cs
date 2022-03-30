using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }
    public double SurfaceArea()
    {
        var surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
        return surfaceArea;
    }
    public double LateralSurfaceArea()
    {
        var lateralSurfaceArea = (2 * length * height) + (2 * width * height);
        return lateralSurfaceArea;
    }
    public double Volume()
    {
        var volume = length * height * width;
        return volume;
    }
    public override string ToString()
    {
        return string.Format($"Surface Area - {SurfaceArea():F2}\n" +
                             $"Lateral Surface Area - {LateralSurfaceArea():F2}\n" +
                             $"Volume - {Volume():F2}");
    }
}

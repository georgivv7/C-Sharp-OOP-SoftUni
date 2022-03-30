using System;
using System.Collections.Generic;
using System.Text;

public abstract class Tyre
{
    private double degradation;
    public string Name { get; }
    public double Hardness { get; }
    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100;
    }
    public virtual void CompleteLap()
    {
        Degradation -= Hardness;
    }
}

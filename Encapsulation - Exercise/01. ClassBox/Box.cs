using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
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
}

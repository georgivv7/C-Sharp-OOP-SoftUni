using System;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp    
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(5d, 6d);
            var circle = new Circle(3d);

            List<Shape> shapes = new List<Shape>() { rectangle, circle };

            shapes.ForEach(sh =>
            {
                Console.WriteLine(sh.CalculateArea());
                Console.WriteLine(sh.CalculatePerimeter());
                Console.WriteLine(sh.Draw());
            });
        }
    }
}

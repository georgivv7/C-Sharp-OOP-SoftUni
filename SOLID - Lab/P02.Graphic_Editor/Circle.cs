using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        public string Type => "Circle";
        public void Draw()
        {
            Console.WriteLine($"I'm {Type}");
        }
    }
}

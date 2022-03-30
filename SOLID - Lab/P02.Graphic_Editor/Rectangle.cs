﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public string Type => "Rectangle";

        public void Draw()
        {
            Console.WriteLine($"I'm {Type}");
        }
    }
}

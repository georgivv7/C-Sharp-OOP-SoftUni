using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }
    public Rectangle(int topLeftX, int topLeftY, int bottomLeftX, int bottomRightY)
    {
        TopLeft = new Point(topLeftX, topLeftY);
        BottomRight = new Point(bottomLeftX, bottomRightY);
    }
    public Rectangle(Func<string> readCoords)
    {
        var coords = readCoords().Split().Select(int.Parse).ToArray();
        TopLeft = new Point(coords[0], coords[1]);
        BottomRight = new Point(coords[2], coords[3]);
    }
    public bool Contains(Point point)
    {
        var result = point.X >= TopLeft.X && point.X <= BottomRight.X &&
            point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
        return result;
    }
}


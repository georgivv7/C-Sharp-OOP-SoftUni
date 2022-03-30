using System;
using System.Linq;
public class StartUp
{
    static void Main(string[] args)
    {
        var rectangle = new Rectangle(Console.ReadLine);
        int pointsCount = int.Parse(Console.ReadLine());
        for (int pointsCounter = 0; pointsCounter < pointsCount; pointsCounter++)
        {
            var point = new Point(Console.ReadLine);
            var result = rectangle.Contains(point);
            Console.WriteLine(result);
        }
    }
}


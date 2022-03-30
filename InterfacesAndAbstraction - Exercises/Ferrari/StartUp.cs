using System;

namespace Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            ICar car = new Ferrari(driver);
            Console.WriteLine($"{car.Model}/{car.Stop()}/{car.Start()}/{car.Driver}");
        }
    }
}

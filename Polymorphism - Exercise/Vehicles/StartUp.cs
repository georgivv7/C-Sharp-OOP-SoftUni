using System;
using System.Text;

namespace Vehicles
{
    public class StartUp   
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(fuelQuantity, fuelConsumption);

            string[] truckInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckInfo[1]);
            fuelConsumption = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(fuelQuantity, fuelConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = commands[0];
                string vehicle = commands[1];
                
                switch (typeCommand)
                {
                    case "Drive":
                        double distance = double.Parse(commands[2]);
                        if (vehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        break;
                    case "Refuel":
                        double refuelAmount = double.Parse(commands[2]);
                        if (vehicle == "Car")
                        {
                            car.Refuel(refuelAmount);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(refuelAmount);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}

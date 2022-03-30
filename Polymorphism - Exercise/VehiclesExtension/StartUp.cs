using System;

namespace VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            double tankCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(fuelQuantity, fuelConsumption,tankCapacity);

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckInfo[1]);
            fuelConsumption = double.Parse(truckInfo[2]);
            tankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(busInfo[1]);
            fuelConsumption = double.Parse(busInfo[2]);
            tankCapacity = double.Parse(busInfo[3]);
            Bus bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeCommand = commands[0];
                string vehicle = commands[1];

                switch (typeCommand)
                {
                    case "DriveEmpty":
                        double distance = double.Parse(commands[2]);
                        Console.WriteLine(bus.Drive(distance));
                        break;
                    case "Drive":
                        distance = double.Parse(commands[2]);
                        if (vehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                        else if (vehicle == "Bus")
                        {
                            Console.WriteLine(bus.DriveWithPeople(distance));
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
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(refuelAmount);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}

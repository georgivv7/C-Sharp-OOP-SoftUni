using System;
using System.Collections.Generic;
using System.Text;

public class DriverFactory
{
    public Driver CreateDriver(string driverType, string name, Car car)
    {
        Driver driver = null;
        if (driverType == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
            return driver;
        }
        else if (driverType == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
            return driver;
        }
        throw new ArgumentException("Invalid Driver Type");
    }
}


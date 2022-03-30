using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public string Driver { get; private set; }
        public string Car { get;private set; }
        public string Model { get; private set; }
        public Ferrari(string driver)
        {
            Driver = driver;
            Car = "Ferrari";
            Model = "488-Spider";
        }
    }
}

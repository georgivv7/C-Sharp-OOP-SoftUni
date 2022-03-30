using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public interface ICar
    {
        string Model { get; }
        string Color { get; }

        void Start()
        {
            Console.WriteLine("Engine start");
        }
        void Stop()
        {
            Console.WriteLine("Breaaak!");
        }


    }
}

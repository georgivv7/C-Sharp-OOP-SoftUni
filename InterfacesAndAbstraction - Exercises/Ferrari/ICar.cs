using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface ICar
    {
        public string Driver { get;}
        public string Car { get;}
        public string Model { get;}

        string Start()
        {
            return "Zadu6avam sA!";
        }

        string Stop()
        {
            return "Brakes!";
        }
    }
}

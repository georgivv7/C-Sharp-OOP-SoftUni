using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }
        int Age { get; }
        void GetName();
        string Country { get; }
    }
}

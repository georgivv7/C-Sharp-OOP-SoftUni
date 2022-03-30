using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public interface IBrowsable
    {
        void Browsing(string site)
        {
            if (site.Any(x=>char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");               
            }
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        void Calling(string phoneNumber)
        {
            if (phoneNumber.All(x=>char.IsDigit(x)))
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }           
        }
    }
}

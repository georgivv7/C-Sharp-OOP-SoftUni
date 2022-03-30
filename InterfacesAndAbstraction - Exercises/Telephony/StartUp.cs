using System;

namespace Telephony
{
    public class StartUp    
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ');

            foreach (var phoneNum in phoneNumbers)
            {
                try
                {
                    ICallable callable = new Smartphone();
                    callable.Calling(phoneNum);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            foreach (var site in sites)
            {
                try
                {
                    IBrowsable browsable = new Smartphone();
                    browsable.Browsing(site);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

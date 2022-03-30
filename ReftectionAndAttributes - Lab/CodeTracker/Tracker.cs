using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n=>n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attribute in attrs)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}

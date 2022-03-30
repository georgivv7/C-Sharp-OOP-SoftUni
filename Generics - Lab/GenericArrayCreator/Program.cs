using System;

namespace GenericArrayCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        private T element;
        public Box(T elem)
        {
            element = elem;
        }
        public override string ToString()
        {
            return $"{this.element.GetType().FullName}: {this.element}";
        }
    }
}

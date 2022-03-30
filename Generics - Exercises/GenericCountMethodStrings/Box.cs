using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace GenericCountMethodStrings 
{
    public class Box<T> : IComparable<T>
        where T : IComparable<T>
    {
        private T element;
        public Box(T elem)
        {
            element = elem;
        }

        public int CompareTo(T other)
        {
            return this.element.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{this.element.GetType().FullName}: {this.element}";        
        }
    }
}

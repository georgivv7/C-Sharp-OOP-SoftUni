using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;  
        public Box()
        {
            items = new List<T>();
        }
        public void Add(T element)
        {
            this.items.Add(element);
        }
        public T Remove()
        {
            var element = items[items.Count - 1];
            this.items.RemoveAt(items.Count - 1);

            return element;
        }
        public int Count { get => items.Count; }
    }
}

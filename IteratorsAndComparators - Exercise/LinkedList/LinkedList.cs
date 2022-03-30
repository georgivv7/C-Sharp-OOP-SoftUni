using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private List<T> linkedList;

        public LinkedList()
        {
            this.linkedList = new List<T>();
        }

        public int Count => this.linkedList.Count;
        public IEnumerator<T> GetEnumerator()
        {
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

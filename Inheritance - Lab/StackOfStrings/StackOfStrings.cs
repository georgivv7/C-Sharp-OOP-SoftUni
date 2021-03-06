using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            return base.Count == 0;
        }      
        public void AddRange(Stack<string> range)
        {
            foreach (var item in range)
            {
                base.Push(item);
            }
        }
    }
}

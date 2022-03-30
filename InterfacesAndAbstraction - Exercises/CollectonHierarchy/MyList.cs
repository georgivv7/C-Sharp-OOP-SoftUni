using System;
using System.Collections.Generic;
using System.Text;

namespace CollectonHierarchy
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList()
            :base()
        {

        }
        public override string Remove()
        {
            string element = List[0];
            List.RemoveAt(0);
            return element;
        }
        public int Used => List.Count;
    }
}

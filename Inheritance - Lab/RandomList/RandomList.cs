using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        Random rand = new Random();
        public string RandomString()
        {
            string result = null;
            if (this.Count > 0)
            {
                var randomIndex = rand.Next(0, this.Count - 1);
                result = this[randomIndex];
                this.RemoveAt(randomIndex);
            }
            return result;            
        }
    }
}

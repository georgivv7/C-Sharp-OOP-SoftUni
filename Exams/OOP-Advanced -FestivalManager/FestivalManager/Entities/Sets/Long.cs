using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        private const int MaxMinutes = 60;
        public Long(string name) 
            : base(name, new TimeSpan(0,MaxMinutes,0))
        {
        }
    }
}

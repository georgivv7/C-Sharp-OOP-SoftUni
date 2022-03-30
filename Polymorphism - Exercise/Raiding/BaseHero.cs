using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name,int power)
        {
            Name = name;
            Power = power;
        }
        public string Name { get; }
        public int Power { get;}
        public virtual string CastAbility()
        {
            return string.Format($"{this.GetType().Name} - {Name} healed for {Power}");
        }
    }
}

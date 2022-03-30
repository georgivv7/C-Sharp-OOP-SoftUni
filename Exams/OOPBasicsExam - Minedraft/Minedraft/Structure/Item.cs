using System;
using System.Collections.Generic;
using System.Text;
public abstract class Item
{
    public string Id { get; private set; }
    public abstract string Type { get;}
    protected Item(string id)
    {
        Id = id;
    }
}


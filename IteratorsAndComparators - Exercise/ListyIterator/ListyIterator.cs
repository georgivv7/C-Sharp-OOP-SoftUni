using System;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T>
{
    private List<T> collection;
    int currentIndex;
    public ListyIterator(params T[] collection)
    {
        this.collection = new List<T>(collection);
        currentIndex = 0;
    }
    public bool Move()
    {
        if (currentIndex < this.collection.Count - 1)
        {
            currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        return this.currentIndex + 1 < this.collection.Count;
    }
    public void Print()
    {
        if (collection.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.collection[currentIndex]);
    }
}


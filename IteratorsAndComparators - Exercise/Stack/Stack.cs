using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class Stack<T> : IEnumerable<T>
{
    private List<T> collection;
    private int currentIndex = -1;
    public Stack()
    {
        this.collection = new List<T>();
    }
    public void Push(params T[] items)
    {
        foreach (var item in items)
        {
            collection.Insert(++currentIndex, item);
        }
    }

    public void Pop()
    {
        if (currentIndex < 0)
        {
            throw new ArgumentException("No elements");
        }

        currentIndex--;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = currentIndex; i >= 0; i--)
        {
            yield return collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

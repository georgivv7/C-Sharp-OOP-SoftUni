﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T> 
{
    private List<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }
    public CustomList(IEnumerable<T> items)
    {
        this.data = new List<T>(items);
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        T element = this.data[index];
        this.data.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        if (this.data.Contains(element))
        {
            return true;
        }

        return false;
    }
    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }
    public int CountGreaterThan(T element)
    {
        int counter = 0;
        foreach (var item in this.data)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
         return this.data.Max();
    }
    public T Min()
    {
        return this.data.Min();
    }
    public override string ToString()
    {
        return String.Join(Environment.NewLine, this.data);
    }
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in this.data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


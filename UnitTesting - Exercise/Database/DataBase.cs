using System;
using System.Collections.Generic;
using System.Text;

public class DataBase
{
    private const int Capacity = 16;

    private int[] values;
    private int currentIndex;

    private DataBase()
    {
        this.values = new int[Capacity];
        this.currentIndex = 0;
    }

    public DataBase(params int[] values)
        :this()
    {
        this.InitializeValues(values);
    }

    private void InitializeValues(int[] inputValues)
    {
        foreach (var item in inputValues)
        {
            this.Add(item);
        }
    }

    public void Add(int element)
    {
        if (this.currentIndex >= Capacity)
        {
            throw new InvalidOperationException("Array is full!");
        }

        this.values[currentIndex] = element;
        currentIndex++;
    }
    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException("Array is empty!");
        }
        currentIndex--;
        this.values[this.currentIndex] = default(int);
    }
    public int[] Fetch()
    {
        int[] newArray = new int[this.currentIndex];
        Array.Copy(this.values, newArray, currentIndex);

        return newArray;
    }
}

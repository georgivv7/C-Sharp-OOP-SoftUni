using System;
using System.Linq;
using System.Collections.Generic;

public class Sorter
{
    public static void Sort<T>(ref CustomList<T> list)
        where T : IComparable<T>
    {
        List<T> sorted = list.OrderBy(e => e).ToList();

        list = new CustomList<T>(sorted);
    }
}
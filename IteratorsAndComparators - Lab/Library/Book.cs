using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators   
{
    public class Book
    {
        public string Title { get; private set; }
        public int Year { get; private set; }
        public IReadOnlyList<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }
    }
}

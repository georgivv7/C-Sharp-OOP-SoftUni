namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal Price_Per_Person = 2.50m; 
        public InsideTable(int tableNumber, int capacity) : 
            base(tableNumber, capacity, Price_Per_Person)   
        { }
    }
}

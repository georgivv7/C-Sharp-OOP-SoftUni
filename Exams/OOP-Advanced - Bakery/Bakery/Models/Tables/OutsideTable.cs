namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal Price_Per_Person = 3.50m;
        public OutsideTable(int tableNumber, int capacity) : 
            base(tableNumber, capacity, Price_Per_Person)
        { }
    }
}

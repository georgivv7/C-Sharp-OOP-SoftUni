namespace Bakery.Core
{
    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<ITable> tables;
        private decimal income;
        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            this.income = 0m;
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
            }

            var message = string.Empty;
            if (drink != null)
            {
                this.drinks.Add(drink);
                message = string.Format(OutputMessages.DrinkAdded,
                    drink.Name, drink.Brand);
            }

            return message;
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            switch (type)
            {
                case "Bread":
                    food = new Bread(name, price);
                    break;
                case "Cake":
                    food = new Cake(name, price);
                    break;
            }

            var message = string.Empty;
            if (food != null)
            {
                this.foods.Add(food);
                message = string.Format(OutputMessages.FoodAdded,
                    food.Name, food.GetType().Name);
            }

            return message;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            switch (type)
            {
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }

            var message = string.Empty;
            if (table != null)
            {
                this.tables.Add(table);
                message = string.Format(OutputMessages.TableAdded,
                    tableNumber);
            }

            return message;
        }
        public string GetFreeTablesInfo()
        {
            var freeTables = this.tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, this.income);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            if (table != null)
            {
                decimal bill = table.GetBill();
                this.income += bill;
                table.Clear();

                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {bill:F2}");
            }

            return sb.ToString().Trim();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var output = string.Empty;
            if (table == null)
            {
                output = string.Format(OutputMessages.WrongTableNumber,
                    tableNumber);
            }
            else
            {
                var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName
                && d.Brand == drinkBrand);
                if (drink == null)
                {
                    output = string.Format(OutputMessages.NonExistentDrink,
                        drinkName, drinkBrand);
                }
                else
                {
                    table.OrderDrink(drink);
                    output = string.Format(OutputMessages.DrinkOrderSuccessful,
                        tableNumber, drinkName, drinkBrand);
                }
            }

            return output;
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var output = string.Empty;
            if (table == null)
            {
                output = string.Format(OutputMessages.WrongTableNumber,
                    tableNumber);
            }
            else
            {
                var food = this.foods.FirstOrDefault(f => f.Name == foodName);
                if (food == null)
                {
                    output = string.Format(OutputMessages.NonExistentFood,
                        foodName);
                }
                else
                {
                    table.OrderFood(food);
                    output = string.Format(OutputMessages.FoodOrderSuccessful,
                        tableNumber, foodName);
                }
            }

            return output;
        }

        public string ReserveTable(int numberOfPeople)
        {
            string result = string.Empty;
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false 
            && t.Capacity >= numberOfPeople);

            if (table != null)
            {
                table.Reserve(numberOfPeople);
                result = string.Format(OutputMessages.TableReserved,
                    table.TableNumber, numberOfPeople);
            }
            else
            {
                result = string.Format(OutputMessages.ReservationNotPossible,
                    numberOfPeople);
            }

            return result;
        }
    }
}

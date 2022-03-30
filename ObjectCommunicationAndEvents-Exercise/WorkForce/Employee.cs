namespace WorkForce
{
    public abstract class Employee
    {
        protected Employee(string name, int hoursPerWeek)
        {
            Name = name;
            HoursPerWeek = hoursPerWeek;
        }
        public string Name { get; private set; }
        public int HoursPerWeek { get; private set; }
    }
}

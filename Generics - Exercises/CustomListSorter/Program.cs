using System;

class Program
{
    static void Main(string[] args)
    {
        CustomList<string> customList = new CustomList<string>();
        string input = string.Empty;
        while ((input = Console.ReadLine())!="END")
        {
            string[] argums = input.Split();
            string command = argums[0];

            switch (command)
            {
                case "Add":
                    customList.Add(argums[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(argums[1]));
                    break;
                case "Contains":
                    Console.WriteLine(customList.Contains(argums[1]));
                    break;
                case "Swap":
                    customList.Swap(int.Parse(argums[1]), int.Parse(argums[2]));
                    break;
                case "Greater":
                    Console.WriteLine(customList.CountGreaterThan(argums[1]));
                    break;
                case "Max":
                    Console.WriteLine(customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(customList.Min());
                    break;
                case "Print":
                    Console.WriteLine(customList);
                    break;
                case "Sort":
                    Sorter.Sort(ref customList);
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < items.Length; i += 2)
            {
                string name = items[i];
                long amount = long.Parse(items[i + 1]);

                string type = string.Empty;

                if (name.Length == 3)
                {
                    type = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    type = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    type = "Gold";
                }

                if (type == "")
                {
                    continue;
                }
                else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
                {
                    continue;
                }

                switch (type)
                {
                    case "Gem":
                        if (bag.ContainsKey(type)==false)
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + amount > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (bag.ContainsKey(type) == false)
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[type].Values.Sum() + amount > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (bag.ContainsKey(type) == false)
                {
                    bag[type] = new Dictionary<string, long>();
                }

                if (bag[type].ContainsKey(name) == false)
                {
                    bag[type][name] = 0;
                }

                bag[type][name] += amount;
                if (type == "Gold")
                {
                    gold += amount;
                }
                else if (type == "Gem")
                {
                    gems += amount;
                }
                else if (type == "Cash")
                {
                    cash += amount;
                }
            }

            foreach (var item in bag)
            {
                Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");
                foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
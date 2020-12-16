using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day13
    {
        public static long Part1(List<string> data)
        {
            var earliestDepart = int.Parse(data.First());
            var buses = data[1]
                .Split(",")
                .Where(n => !n.Equals("x"))
                .Select(n => int.Parse(n))
                .ToList();

            var earliestBusTimes = new List<int>();
            foreach (var bus in buses)
            {
                earliestBusTimes.Add(bus - (earliestDepart % bus) + earliestDepart);
            }

            var earliestBus = earliestBusTimes.Min();

            for (int i = 0; i < earliestBusTimes.Count; i++)
            {
                if (earliestBusTimes[i] == earliestBus)
                {
                    return (earliestBus - earliestDepart) * buses[i];
                }
            }

            return -1;
        }

        public static long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }
    }
}
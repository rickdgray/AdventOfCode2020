using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day16
    {
        public static long Part1(List<string> data)
        {
            var rules = new Dictionary<string, string>();
            var myTicket = new List<int>();
            var nearbyTickets = new List<List<int>>();

            var lineNumber = 0;
            for (int i = lineNumber; i < data.Count; i++)
            {
                var line = data[i];

                if (string.IsNullOrEmpty(line))
                {
                    lineNumber = i;
                    break;
                }

                var rule = line.Split(": ");
                rules.Add(rule[0], rule[1]);
            }
            lineNumber += 2;
            myTicket.AddRange(data[lineNumber].Split(",").Select(n => int.Parse(n)).ToList());
            lineNumber += 3;
            for (int i = lineNumber; i < data.Count; i++)
            {
                var line = data[i];

                if (string.IsNullOrEmpty(line))
                {
                    break;
                }

                nearbyTickets.Add(new List<int>());
                nearbyTickets.Last().AddRange(data[i].Split(",").Select(n => int.Parse(n)).ToList());
            }

            var invalidFields = new List<int>();
            var bounds = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();
            foreach (var (_, rule) in rules)
            {
                var ruleTokens = rule.Split(" or ");
                var firstRule = ruleTokens[0].Split("-");
                var secondRule = ruleTokens[1].Split("-");

                bounds.Add(Tuple.Create(Tuple.Create(int.Parse(firstRule[0]), int.Parse(firstRule[1])), Tuple.Create(int.Parse(secondRule[0]), int.Parse(secondRule[1]))));
            }

            foreach (var nearbyTicket in nearbyTickets)
            {
                foreach (var field in nearbyTicket)
                {
                    if (bounds.All(b => field < b.Item1.Item1 || (field > b.Item1.Item2 && field < b.Item2.Item1) || field > b.Item2.Item2))
                    {
                        invalidFields.Add(field);
                    }
                }
            }

            return invalidFields.Sum();
        }

        public static long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Program
    {
        static void Main()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "input.txt");
            using var fileStream = File.OpenRead(path);
            using var streamReader = new StreamReader(fileStream);

            var data = new List<string>();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                data.Add(line);
            }

            //currently working on:
            Day11.Part1(data);
        }
    }

    public class Day1
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day2
    {
        public static void Part1(List<string> data)
        {
            var count = 0;

            foreach (var item in data)
            {
                var tokens = item.Split(" ");

                if (tokens.Length != 3)
                    throw new Exception("fucked");

                var numberOfLettersTokens = tokens[0].Split("-");

                var policyMinimumNumber = int.Parse(numberOfLettersTokens[0]);
                var policyMaximumNumber = int.Parse(numberOfLettersTokens[1]);
                var policyLetter = tokens[1].ToCharArray().First();
                var policyPassword = tokens[2];

                var concordance = new Dictionary<char, int>();
                foreach (var letter in policyPassword)
                {
                    if (!concordance.ContainsKey(letter))
                    {
                        concordance.Add(letter, 0);
                    }

                    concordance[letter] = concordance[letter] + 1;
                }

                if (concordance.ContainsKey(policyLetter))
                {
                    var numberOfInstances = concordance[policyLetter];

                    if (numberOfInstances < policyMinimumNumber || numberOfInstances > policyMaximumNumber)
                        count++;
                }
                else
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }

    public class Day3
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day4
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day5
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day6
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day7
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day8
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day9
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day10
    {
        public static void Part1(List<string> data)
        {
            var adapters = new List<int>
            {
                0
            };

            foreach (var adapter in data)
            {
                adapters.Add(int.Parse(adapter));
            }

            adapters.Sort();

            adapters.Add(adapters.Last() + 3);

            var threeCount = 0;
            var oneCount = 0;
            for (var i = 0; i < adapters.Count - 1; i++)
            {
                if (adapters[i + 1] - adapters[i] == 3)
                {
                    threeCount++;
                }
                else if (adapters[i + 1] - adapters[i] == 1)
                {
                    oneCount++;
                }
            }

            Console.WriteLine(threeCount * oneCount);
        }

        public void Part2(List<string> data)
        {
            var adapters = new List<int>
            {
                0
            };

            foreach (var adapter in data)
            {
                adapters.Add(int.Parse(adapter));
            }

            adapters.Sort();

            adapters.Add(adapters.Last() + 3);

            var total = 0;
            var cache = new Dictionary<int, int>();

            for (var i = adapters.Count - 1; i > 0; i--)
            {
                for (var j = 1; j < 4; j++)
                {
                    if (i + j >= adapters.Count)
                        break;

                    if (adapters[i + j] - adapters[i] > 3)
                        break;

                    if (cache.ContainsKey(i))
                    {
                        cache[i] = cache[i] + cache[i + j];
                        break;
                    }
                    else
                    {
                        cache.Add(i, 1);
                    }
                }
            }

            Console.WriteLine(total);
        }
    }

    public class Day11
    {
        public static void Part1(List<string> data)
        {

        }
    }

    public class Day12
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day13
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day14
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day15
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day16
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day17
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day18
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day19
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day20
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day21
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day22
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day23
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day24
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }

    public class Day25
    {
        public static void Part1()
        {
            throw new NotImplementedException();
        }
    }
}

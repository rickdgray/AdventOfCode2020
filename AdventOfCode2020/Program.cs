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

            //currently working on:
            Day10.Part1(streamReader);
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
        public static void Part1(StreamReader streamReader)
        {
            var count = 0;

            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var tokens = line.Split(" ");

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
        public static void Part1(StreamReader streamReader)
        {
            var input = "16 10 15 5 1 11 7 19 6 12 4";

            var adapters = input.Split(" ");

        }
    }

    public class Day11
    {
        public static void Part1()
        {
            throw new NotImplementedException();
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

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
            var day11 = new Day11();
            day11.Part1(data);
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
        public void Part1(List<string> data)
        {
            var rowCount = data.Count + 2;
            var colCount = data.First().Length + 2;

            var seatingChart = new Cell[rowCount, colCount];

            //pad spaces around chairs
            for (int i = 0; i < colCount; i++)
            {
                seatingChart[0, i] = Cell.Floor;
            }
            for (int i = 0; i < colCount; i++)
            {
                seatingChart[rowCount - 1, i] = Cell.Floor;
            }
            for (int i = 0; i < rowCount; i++)
            {
                seatingChart[i, 0] = Cell.Floor;
            }
            for (int i = 0; i < rowCount; i++)
            {
                seatingChart[i, colCount - 1] = Cell.Floor;
            }

            for (int i = 0; i < rowCount - 2; i++)
            {
                var seats = data[i].ToArray();
                for (int j = 0; j < colCount - 2; j++)
                {
                    seatingChart[i + 1, j + 1] = (seats[j]) switch
                    {
                        '.' => Cell.Floor,
                        'L' => Cell.Empty,
                        '#' => Cell.Occupied,
                        _ => throw new Exception("Invalid input"),
                    };
                }
            }

            Cell[,] previousSeatingChart = null;

            //start iterating
            while (!SeatingChartsAreEqual(rowCount, colCount, previousSeatingChart, seatingChart))
            {
                previousSeatingChart = (Cell[,])seatingChart.Clone();

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        if (previousSeatingChart[i, j] == Cell.Floor)
                            continue;

                        var (leftI, leftJ) = GetAdjacentCell(i, j, Direction.Left);
                        var left = previousSeatingChart[leftI, leftJ];

                        var (upLeftI, upLeftJ) = GetAdjacentCell(i, j, Direction.UpLeft);
                        var upLeft = previousSeatingChart[upLeftI, upLeftJ];

                        var (upI, upJ) = GetAdjacentCell(i, j, Direction.Up);
                        var up = previousSeatingChart[upI, upJ];

                        var (upRightI, upRightJ) = GetAdjacentCell(i, j, Direction.UpRight);
                        var upRight = previousSeatingChart[upRightI, upRightJ];

                        var (rightI, rightJ) = GetAdjacentCell(i, j, Direction.Right);
                        var right = previousSeatingChart[rightI, rightJ];

                        var (downRightI, downRightJ) = GetAdjacentCell(i, j, Direction.DownRight);
                        var downRight = previousSeatingChart[downRightI, downRightJ];

                        var (downI, downJ) = GetAdjacentCell(i, j, Direction.Down);
                        var down = previousSeatingChart[downI, downJ];

                        var (downLeftI, downLeftJ) = GetAdjacentCell(i, j, Direction.DownLeft);
                        var downLeft = previousSeatingChart[downLeftI, downLeftJ];

                        //if empty and all adjecent empty set full
                        if (previousSeatingChart[i, j] == Cell.Empty
                            && left != Cell.Occupied
                            && upLeft != Cell.Occupied
                            && up != Cell.Occupied
                            && upRight != Cell.Occupied
                            && right != Cell.Occupied
                            && downRight != Cell.Occupied
                            && down != Cell.Occupied
                            && downLeft != Cell.Occupied)
                        {
                            seatingChart[i, j] = Cell.Occupied;
                        }
                        else if (previousSeatingChart[i, j] == Cell.Occupied)
                        {
                            var count = 0;

                            if (left == Cell.Occupied) count++;
                            if (upLeft == Cell.Occupied) count++;
                            if (up == Cell.Occupied) count++;
                            if (upRight == Cell.Occupied) count++;
                            if (right == Cell.Occupied) count++;
                            if (downRight == Cell.Occupied) count++;
                            if (down == Cell.Occupied) count++;
                            if (downLeft == Cell.Occupied) count++;

                            if (count >= 4)
                            {
                                seatingChart[i, j] = Cell.Empty;
                            }
                        }
                    }
                }
            }

            var finalCount = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (seatingChart[i, j] == Cell.Occupied)
                        finalCount++;
                }
            }

            Console.WriteLine(finalCount);
        }

        public static bool SeatingChartsAreEqual(int rowCount, int colCount, Cell[,] a, Cell[,] b)
        {
            if (a == null)
                return false;

            if (b == null)
                return false;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (a[i, j] != b[i, j])
                        return false;
                }
            }

            return true;
        }

        public Tuple<int, int> GetAdjacentCell(int i, int j, Direction direction)
        {
            return direction switch
            {
                Direction.Left => Tuple.Create(i, j - 1),
                Direction.UpLeft => Tuple.Create(i - 1, j - 1),
                Direction.Up => Tuple.Create(i - 1, j),
                Direction.UpRight => Tuple.Create(i - 1, j + 1),
                Direction.Right => Tuple.Create(i, j + 1),
                Direction.DownRight => Tuple.Create(i + 1, j + 1),
                Direction.Down => Tuple.Create(i + 1, j),
                Direction.DownLeft => Tuple.Create(i + 1, j - 1)
            };
        }

        public enum Cell
        {
            Floor = -1,
            Empty = 0,
            Occupied = 1
        }

        public enum Direction
        {
            Left = 0,
            UpLeft = 1,
            LeftUp = 1,
            Up = 2,
            UpRight = 3,
            RightUp = 3,
            Right = 4,
            DownRight = 5,
            RightDown = 5,
            Down = 6,
            DownLeft = 7,
            LeftDown = 7
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

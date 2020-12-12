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
            Day1.Part2(data);
        }
    }

    public class Day1
    {
        public static void Part1(List<string> data)
        {
            var complementLookup = new Dictionary<int, int>();
            foreach (var num in data)
            {
                var numAsInt = int.Parse(num);
                complementLookup.Add(numAsInt, 2020 - numAsInt);
            }

            foreach (var (num, comp) in complementLookup)
            {
                if (complementLookup.ContainsKey(comp))
                {
                    Console.WriteLine(num * comp);
                    break;
                }
            }    
        }

        public static void Part2(List<string> data)
        {
            var numbers = new List<int>();
            foreach (var num in data)
            {
                numbers.Add(int.Parse(num));
            }

            for (int i = 0; i < numbers.Count; i++)
                for (int j = i + 1; j < numbers.Count; j++)
                    for (int k = j + 1; k < numbers.Count; k++)
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            Console.WriteLine(numbers[i] * numbers[j] * numbers[k]);

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
            var rowCount = data.Count + 2;
            var colCount = data.First().Length + 2;
            var directions = Enum
                .GetValues(typeof(Direction))
                .Cast<Direction>()
                .ToList();

            var seatingChart = new Cell[rowCount, colCount];

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

            while (!SeatingChartsAreEqual(rowCount, colCount, previousSeatingChart, seatingChart))
            {
                previousSeatingChart = (Cell[,])seatingChart.Clone();

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        if (previousSeatingChart[i, j] == Cell.Floor)
                            continue;

                        var adjacentSeats = new List<Cell>();

                        foreach (var direction in directions)
                        {
                            var (adjacentCellRow, adjacentCellCol) = GetAdjacentCell(i, j, direction);
                            adjacentSeats.Add(previousSeatingChart[adjacentCellRow, adjacentCellCol]);
                        }

                        if (previousSeatingChart[i, j] == Cell.Empty
                            && adjacentSeats.All(s => s != Cell.Occupied))
                        {
                            seatingChart[i, j] = Cell.Occupied;
                        }
                        else if (previousSeatingChart[i, j] == Cell.Occupied
                            && adjacentSeats.FindAll(s => s == Cell.Occupied).Count >= 4)
                        {
                            seatingChart[i, j] = Cell.Empty;
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

        public static void Part2(List<string> data)
        {
            var rowCount = data.Count + 2;
            var colCount = data.First().Length + 2;
            var directions = Enum
                .GetValues(typeof(Direction))
                .Cast<Direction>()
                .ToList();

            var seatingChart = new Cell[rowCount, colCount];

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

            while (!SeatingChartsAreEqual(rowCount, colCount, previousSeatingChart, seatingChart))
            {
                previousSeatingChart = (Cell[,])seatingChart.Clone();

                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        if (previousSeatingChart[i, j] == Cell.Floor)
                            continue;

                        var adjacentSeats = new List<Cell>();

                        foreach (var direction in directions)
                        {
                            var currentAdjacentCell = Cell.Floor;

                            var adjacentCellRow = i;
                            var adjacentCellCol = j;

                            do
                            {
                                (adjacentCellRow, adjacentCellCol) = GetAdjacentCell(adjacentCellRow, adjacentCellCol, direction);
                                currentAdjacentCell = previousSeatingChart[adjacentCellRow, adjacentCellCol];
                            } while (currentAdjacentCell == Cell.Floor
                                && adjacentCellRow > 0
                                && adjacentCellCol > 0
                                && adjacentCellRow < rowCount - 1
                                && adjacentCellCol < colCount - 1);

                            adjacentSeats.Add(currentAdjacentCell);
                        }

                        if (previousSeatingChart[i, j] == Cell.Empty
                            && adjacentSeats.All(s => s != Cell.Occupied))
                        {
                            seatingChart[i, j] = Cell.Occupied;
                        }
                        else if (previousSeatingChart[i, j] == Cell.Occupied
                            && adjacentSeats.FindAll(s => s == Cell.Occupied).Count >= 5)
                        {
                            seatingChart[i, j] = Cell.Empty;
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

        public static Tuple<int, int> GetAdjacentCell(int i, int j, Direction direction)
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
                Direction.DownLeft => Tuple.Create(i + 1, j - 1),
                _ => throw new ArgumentException("Invalid Direction")
            };
        }

        public enum Cell
        {
            Floor,
            Empty,
            Occupied
        }

        public enum Direction
        {
            Left,
            UpLeft,
            Up,
            UpRight,
            Right,
            DownRight,
            Down,
            DownLeft
        }
    }

    public class Day12
    {
        public static void Part1(List<string> data)
        {
            double x = 0;
            double y = 0;
            double radians = 0;

            foreach (var line in data)
            {
                var instruction = line.Substring(0, 1);
                var distance = int.Parse(line.Substring(1));

                switch(instruction)
                {
                    case "N":
                        y += distance;
                        break;
                    case "S":
                        y -= distance;
                        break;
                    case "E":
                        x += distance;
                        break;
                    case "W":
                        x -= distance;
                        break;
                    case "L":
                        radians += distance * Math.PI / 180;
                        break;
                    case "R":
                        radians -= distance * Math.PI / 180;
                        break;
                    case "F":
                        x += distance * Math.Cos(radians);
                        y += distance * Math.Sin(radians);
                        break;
                }
            }

            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }

        public static void Part2(List<string> data)
        {
            double waypointX = 10;
            double waypointY = 1;

            double shipX = 0;
            double shipY = 0;

            foreach (var line in data)
            {
                var instruction = line.Substring(0, 1);
                var distance = int.Parse(line.Substring(1));

                switch (instruction)
                {
                    case "N":
                        waypointY += distance;
                        break;
                    case "S":
                        waypointY -= distance;
                        break;
                    case "E":
                        waypointX += distance;
                        break;
                    case "W":
                        waypointX -= distance;
                        break;
                    case "L":
                        {
                            switch (distance)
                            {
                                case 90:
                                    {
                                        var tmp = waypointX;
                                        waypointX = -1 * waypointY;
                                        waypointY = tmp;
                                        break;
                                    }
                                case 180:
                                    {
                                        waypointX = -1 * waypointX;
                                        waypointY = -1 * waypointY;
                                        break;
                                    }
                                case 270:
                                    {
                                        var tmp = waypointX;
                                        waypointX = waypointY;
                                        waypointY = -1 * tmp;
                                        break;
                                    }
                                default:
                                    throw new ArgumentException();
                            }
                            break;
                        }
                    case "R":
                        {
                            switch (distance)
                            {
                                case 90:
                                    {
                                        var tmp = waypointX;
                                        waypointX = waypointY;
                                        waypointY = -1 * tmp;
                                        break;
                                    }
                                case 180:
                                    {
                                        waypointX = -1 * waypointX;
                                        waypointY = -1 * waypointY;
                                        break;
                                    }
                                case 270:
                                    {
                                        var tmp = waypointX;
                                        waypointX = -1 * waypointY;
                                        waypointY = tmp;
                                        break;
                                    }
                                default:
                                    throw new ArgumentException();
                            }
                            break;
                        }
                    case "F":
                        {
                            shipX += distance * waypointX;
                            shipY += distance * waypointY;
                            break;
                        }
                }
            }

            Console.WriteLine(Math.Abs(shipX) + Math.Abs(shipY));
        }
    }

    public class Day13
    {
        public static void Part1(List<string> data)
        {

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

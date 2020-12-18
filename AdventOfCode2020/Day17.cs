using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class Day17
    {
        public static long Part1(List<string> data)
        {
            return -1;
        }

        public static long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }

        public static Tuple<int, int, int> GetAdjacentCell(int i, int j, int k, Direction direction)
        {
            return direction switch
            {
                Direction.Left => Tuple.Create(i, j - 1, k),
                Direction.UpLeft => Tuple.Create(i - 1, j - 1, k),
                Direction.Up => Tuple.Create(i - 1, j, k),
                Direction.UpRight => Tuple.Create(i - 1, j + 1, k),
                Direction.Right => Tuple.Create(i, j + 1, k),
                Direction.DownRight => Tuple.Create(i + 1, j + 1, k),
                Direction.Down => Tuple.Create(i + 1, j, k),
                Direction.DownLeft => Tuple.Create(i + 1, j - 1, k),
                Direction.BackLeft => Tuple.Create(i, j - 1, k - 1),
                Direction.BackUpLeft => Tuple.Create(i - 1, j - 1, k - 1),
                Direction.BackUp => Tuple.Create(i - 1, j, k - 1),
                Direction.BackUpRight => Tuple.Create(i - 1, j + 1, k - 1),
                Direction.BackRight => Tuple.Create(i, j + 1, k - 1),
                Direction.BackDownRight => Tuple.Create(i + 1, j + 1, k - 1),
                Direction.BackDown => Tuple.Create(i + 1, j, k - 1),
                Direction.BackDownLeft => Tuple.Create(i + 1, j - 1, k - 1),
                Direction.FrontLeft => Tuple.Create(i, j - 1, k + 1),
                Direction.FrontUpLeft => Tuple.Create(i - 1, j - 1, k + 1),
                Direction.FrontUp => Tuple.Create(i - 1, j, k + 1),
                Direction.FrontUpRight => Tuple.Create(i - 1, j + 1, k + 1),
                Direction.FrontRight => Tuple.Create(i, j + 1, k + 1),
                Direction.FrontDownRight => Tuple.Create(i + 1, j + 1, k + 1),
                Direction.FrontDown => Tuple.Create(i + 1, j, k + 1),
                Direction.FrontDownLeft => Tuple.Create(i + 1, j - 1, k + 1),
                _ => throw new ArgumentException("Invalid Direction")
            };
        }

        public enum Cell
        {
            Inactive,
            Active
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
            DownLeft,
            BackLeft,
            BackUpLeft,
            BackUp,
            BackUpRight,
            BackRight,
            BackDownRight,
            BackDown,
            BackDownLeft,
            FrontLeft,
            FrontUpLeft,
            FrontUp,
            FrontUpRight,
            FrontRight,
            FrontDownRight,
            FrontDown,
            FrontDownLeft
        }
    }
}
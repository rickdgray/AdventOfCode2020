using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day18
    {
        public static long Part1(List<string> data)
        {
            var rootNode = new Node
            {
                Children = new List<Node>()
            };

            foreach (var digit in data.First())
            {
                switch (digit)
                {
                    case '(':
                        //recurse
                        break;
                    case ')':
                        //base case
                        break;
                    case '+':
                    case '*':
                        rootNode.Children.Add(new Node
                        {
                            Type = Type.Operation,
                            Value = digit,
                            Children = new List<Node>()
                        });
                        break;
                    default:
                        break;
                }
            }
        }

        public static long Part2(List<string> data)
        {
            throw new NotImplementedException();
        }

        public long RecursivelyOperate(string line, Node currentNode)
        {
            foreach (var digit in line)
            {
                switch (digit)
                {
                    case '(':
                        RecursivelyOperate(line, )
                        break;
                    case ')':
                        //base case
                        break;
                    case '+':
                    case '*':
                        rootNode.Children.Add(new Node
                        {
                            Type = Type.Operation,
                            Value = digit,
                            Children = new List<Node>()
                        });
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public class Node
    {
        public Type Type { get; set; }
        public char Value { get; set; }
        public List<Node> Children { get; set; }
    }

    public enum Type
    {
        Number,
        Operation
    }
}
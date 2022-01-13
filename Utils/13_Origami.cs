using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Origami
    {
        private static HashSet<Point> _dots = new HashSet<Point>();
        private static List<(char axis, int value)> _folds = new List<(char axis, int value)>();

        public static int GetDotsCount(string[] input)
        {
            ReadData(input);

            var fold = _folds[0];
            HashSet<Point> dotsToAdd = new HashSet<Point>();
            HashSet<Point> dotsToRemove = new HashSet<Point>();
            foreach (var point in _dots)
            {
                if (fold.axis == 'x' && point.X > fold.value)
                {
                    var newX = 2 * fold.value - point.X;
                    dotsToAdd.Add(new Point(newX, point.Y));
                    dotsToRemove.Add(point);
                }
                else if (fold.axis == 'y' && point.Y > fold.value)
                {
                    var newY = 2 * fold.value - point.Y;
                    dotsToAdd.Add(new Point(point.X, newY));
                    dotsToRemove.Add(point);
                }
            }

            _dots.UnionWith(dotsToAdd);
            _dots.ExceptWith(dotsToRemove);

            return _dots.Count;
        }

        private static void ReadData(string[] input)
        {
            bool readPoints = true;
            foreach (var line in input)
            {
                if (line == "")
                {
                    readPoints = false;
                    continue;
                }

                if (readPoints)
                {
                    var lineParts = line.Split(',');
                    var x = Convert.ToInt32(lineParts[0]);
                    var y = Convert.ToInt32(lineParts[1]);
                    _dots.Add(new Point(x, y));
                }
                else
                {
                    var lineParts = line.Split('=');
                    _folds.Add((lineParts[0].Last(), Convert.ToInt32(lineParts[1])));
                }
            }
        }
    }

    public class Origami2
    {
        private static HashSet<Point> _dots = new HashSet<Point>();
        private static List<(char axis, int value)> _folds = new List<(char axis, int value)>();

        public static string[] GetLetters(string[] input)
        {
            ReadData(input);

            foreach (var fold in _folds)
            {
                HashSet<Point> dotsToAdd = new HashSet<Point>();
                HashSet<Point> dotsToRemove = new HashSet<Point>();
                foreach (var point in _dots)
                {
                    if (fold.axis == 'x' && point.X > fold.value)
                    {
                        var newX = 2 * fold.value - point.X;
                        dotsToAdd.Add(new Point(newX, point.Y));
                        dotsToRemove.Add(point);
                    }
                    else if (fold.axis == 'y' && point.Y > fold.value)
                    {
                        var newY = 2 * fold.value - point.Y;
                        dotsToAdd.Add(new Point(point.X, newY));
                        dotsToRemove.Add(point);
                    }
                }

                _dots.UnionWith(dotsToAdd);
                _dots.ExceptWith(dotsToRemove);
            }

            return GetLetters();
        }

        private static string[] GetLetters()
        {
            int rowsCount = _dots.Max(x => x.Y) + 1;
            int columnsCount = _dots.Max(x => x.X) + 1;
            char[,] letters = new char[rowsCount, columnsCount];
            foreach (var point in _dots)
            {
                letters[point.Y, point.X] = '#';
            }

            string[] resultLines = new string[rowsCount];
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    if (letters[row, column] == '\0')
                        sb.Append(' ');
                    else
                        sb.Append(letters[row, column]);
                }

                resultLines[row] = sb.ToString();
                sb.Clear();
            }
            return resultLines;
        }

        private static void ReadData(string[] input)
        {
            bool readPoints = true;
            foreach (var line in input)
            {
                if (line == "")
                {
                    readPoints = false;
                    continue;
                }

                if (readPoints)
                {
                    var lineParts = line.Split(',');
                    var x = Convert.ToInt32(lineParts[0]);
                    var y = Convert.ToInt32(lineParts[1]);
                    _dots.Add(new Point(x, y));
                }
                else
                {
                    var lineParts = line.Split('=');
                    _folds.Add((lineParts[0].Last(), Convert.ToInt32(lineParts[1])));
                }
            }
        }
    }

    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class SmokeBasing
    {
        private static int _rowsCount = 0;
        private static int _columnsCount = 0;
        private static int[,] _map;

        public static int GetLowerstPointsRisk(string[] input)
        {
            InitData(input);

            int result = 0;
            for (int row = 0; row < _rowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    if (row - 1 >= 0 && _map[row, column] >= _map[row - 1, column])
                        continue;

                    if (column - 1 >= 0 && _map[row, column] >= _map[row, column - 1])
                        continue;

                    if (row + 1 < _rowsCount && _map[row, column] >= _map[row + 1, column])
                        continue;

                    if (column + 1 < _columnsCount && _map[row, column] >= _map[row, column + 1])
                        continue;

                    result += _map[row, column] + 1;
                }
            }

            return result;
        }

        private static void InitData(string[] input)
        {
            _columnsCount = input[0].Length;
            _rowsCount = input.Length;
            _map = new int[_rowsCount, _columnsCount];
            for (int row = 0; row < _rowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    _map[row, column] = (int)char.GetNumericValue(input[row][column]);
                }
            }
        }
    }

    public class SmokeBasing2
    {
        private static int _rowsCount = 0;
        private static int _columnsCount = 0;
        private static int[,] _map;

        public static int GetLagestBasins(string[] input)
        {
            InitData(input);

            List<int> basinsSquares = new List<int>();
            for (int row = 0; row < _rowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    var square = GetBasinSquare(row, column);
                    if (square != 0)
                        basinsSquares.Add(square);
                }
            }

            return basinsSquares.OrderByDescending(x => x).Take(3).Aggregate((x, y) => x * y);
        }

        private static int GetBasinSquare(int row, int column)
        {
            if (row < 0 || row >= _rowsCount || column < 0 || column >= _columnsCount || _map[row, column] == 9)
                return 0;

            _map[row, column] = 9;

            int square = 1;
            square += GetBasinSquare(row + 1, column);
            square += GetBasinSquare(row - 1, column);
            square += GetBasinSquare(row, column + 1);
            square += GetBasinSquare(row, column - 1);

            return square;
        }

        private static void InitData(string[] input)
        {
            _columnsCount = input[0].Length;
            _rowsCount = input.Length;
            _map = new int[_rowsCount, _columnsCount];
            for (int row = 0; row < _rowsCount; row++)
            {
                for (int column = 0; column < _columnsCount; column++)
                {
                    _map[row, column] = (int)char.GetNumericValue(input[row][column]);
                }
            }
        }
    }
}

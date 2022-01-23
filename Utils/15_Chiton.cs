using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class Chiton
    {
        private static int _rows;
        private static int _columns;
        private static int[,] _map;

        public static int GetLowestTotalRisk(string[] input)
        {
            _rows = input.Length;
            _columns = input[0].Length;

            _map = new int[_rows, _columns]; ;
            int[,] visitedCells = new int[_rows, _columns];
            ReadData(input);

            List<(int row, int col)> cellsToVisit = new List<(int row, int col)>();
            cellsToVisit.Add((0, 0));
            visitedCells[0, 0] = _map[0, 0];
            while (cellsToVisit.Count > 0)
            {
                var cell = cellsToVisit[0];
                cellsToVisit.RemoveAt(0);

                Action<int, int> checkPosition = (int row, int column) =>
                {
                    var cellValue = visitedCells[row, column];
                    var risk = visitedCells[cell.row, cell.col] + _map[row, column];
                    if (cellValue == 0 || cellValue > risk)
                    {
                        visitedCells[row, column] = risk;
                        cellsToVisit.Add((row, column));
                    }
                };

                if (cell.row > 0)
                    checkPosition(cell.row - 1, cell.col);
                if (cell.col + 1 < _columns)
                    checkPosition(cell.row, cell.col + 1);
                if (cell.row + 1 < _rows)
                    checkPosition(cell.row + 1, cell.col);
                if (cell.col > 0)
                    checkPosition(cell.row, cell.col - 1);
            }

            return visitedCells[_rows - 1, _columns - 1];
        }

        private static void ReadData(string[] input)
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    _map[row, column] = (int)char.GetNumericValue(input[row][column]);
                }
            }

            _map[0, 0] = 0;
        }
    }

    public class Chiton2
    {
        private static int _inputRows;
        private static int _inputColumns;
        private static int _rows;
        private static int _columns;
        private static int[,] _map;

        public static int GetLowestTotalRisk(string[] input)
        {
            _inputRows = input.Length;
            _inputColumns = input[0].Length;
            _rows = _inputRows * 5;
            _columns = _inputColumns * 5;

            _map = new int[_rows, _columns]; ;
            int[,] visitedCells = new int[_rows, _columns];
            ReadData(input);

            List<(int row, int col)> cellsToVisit = new List<(int row, int col)>();
            cellsToVisit.Add((0, 0));
            visitedCells[0, 0] = _map[0, 0];
            while (cellsToVisit.Count > 0)
            {
                var cell = cellsToVisit[0];
                cellsToVisit.RemoveAt(0);

                Action<int, int> checkPosition = (int row, int column) =>
                {
                    var cellValue = visitedCells[row, column];
                    var risk = visitedCells[cell.row, cell.col] + _map[row, column];
                    if (cellValue == 0 || cellValue > risk)
                    {
                        visitedCells[row, column] = risk;
                        cellsToVisit.Add((row, column));
                    }
                };

                if (cell.row > 0)
                    checkPosition(cell.row - 1, cell.col);
                if (cell.col + 1 < _columns)
                    checkPosition(cell.row, cell.col + 1);
                if (cell.row + 1 < _rows)
                    checkPosition(cell.row + 1, cell.col);
                if (cell.col > 0)
                    checkPosition(cell.row, cell.col - 1);
            }

            return visitedCells[_rows - 1, _columns - 1];
        }

        private static void ReadData(string[] input)
        {
            for (int row = 0; row < _inputRows; row++)
            {
                for (int column = 0; column < _inputColumns; column++)
                {
                    _map[row, column] = (int)char.GetNumericValue(input[row][column]);
                }
            }

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _inputColumns; column++)
                {
                    if (_map[row, column] != 0)
                        continue;

                    int valueRowIndex = row - _inputRows < 0 ? row : row - _inputRows;

                    int cellValue = _map[valueRowIndex, column] + 1;
                    _map[row, column] = cellValue > 9 ? 1 : cellValue;
                }
            }

            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    if (_map[row, column] != 0)
                        continue;

                    int valueColumnIndex = column - _inputColumns < 0 ? column : column - _inputColumns;

                    int cellValue = _map[row, valueColumnIndex] + 1;
                    _map[row, column] = cellValue > 9 ? 1 : cellValue;
                }
            }

            _map[0, 0] = 0;
        }
    }
}

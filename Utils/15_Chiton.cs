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
}

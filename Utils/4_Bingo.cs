using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class Bingo
    {
        private const int BOARD_SIZE = 5;

        public static int Play(string[] input)
        {
            List<Board> boards = new List<Board>();
            List<int> randomNumbers = input[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();

            int index = 2;
            while (index + BOARD_SIZE <= input.Length)
            {
                List<string> nextBoardInfo = new List<string>(5);
                for (int i = index; i < index + BOARD_SIZE; i++)
                {
                    nextBoardInfo.Add(input[i]);
                }

                boards.Add(new Board(nextBoardInfo));
                index += BOARD_SIZE + 1;
            }

            var remainingBoards = new List<Board>();
            remainingBoards.AddRange(boards);
            foreach (int number in randomNumbers)
            {
                var winningBoards = new List<Board>();
                foreach (Board board in remainingBoards)
                {
                    if (board.IsBingo(number))
                    {
                        if (remainingBoards.Count == 1)
                            return board.SummOfUnmarkedNumbers * number;

                        winningBoards.Add(board);
                    }
                }

                remainingBoards.RemoveAll(x => winningBoards.Contains(x));
            }

            return 0;
        }
    }

    public class Board
    {
        private int _size;
        private int[,] _board;
        private int[] _markedCountInRows;
        private int[] _markedCountInColumns;

        private int _totalSum = 0;
        private int _markedNumbersSum = 0;

        public int SummOfUnmarkedNumbers
        {
            get { return _totalSum - _markedNumbersSum; }
        }

        public bool Win
        {
            get { return _markedCountInColumns.Any(x => x == 5) || _markedCountInRows.Any(x => x == 5); }
        }

        public Board(List<string> boardInfo)
        {
            _size = boardInfo.Count;

            _markedCountInRows = new int[_size];
            _markedCountInColumns = new int[_size];

            _board = InitBoard(boardInfo);
        }

        private int[,] InitBoard(List<string> boardInfo)
        {
            int[,] board = new int[_size, _size];
            for (int row = 0; row < _size; row++)
            {
                string[] line = boardInfo[row].Split(' ').Where(x => x != "").ToArray();
                for (int column = 0; column < _size; column++)
                {
                    int number = Convert.ToInt32(line[column]);
                    board[row, column] = number;
                    _totalSum += number;
                };
            }

            return board;
        }

        public bool IsBingo(int number)
        {
            if (Win)
                return Win;

            for (int row = 0; row < _size; row++)
            {
                for (int column = 0; column < _size; column++)
                {
                    if (_board[row, column] == number)
                    {
                        _markedCountInColumns[column]++;
                        _markedCountInRows[row]++;
                        _markedNumbersSum += _board[row, column];
                    }
                };
            }

            return Win;
        }
    }
}

namespace Utils
{
    public static class DumboOctopus
    {
        private const int _mapSize = 10;
        private static int[,] _map = new int[_mapSize, _mapSize];

        public static int GetTotalFlashes(string[] input)
        {
            ReadData(input);

            int flashesCount = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int row = 0; row < _mapSize; row++)
                    for (int column = 0; column < _mapSize; column++)
                    {
                        _map[row, column] += 1;
                    }

                for (int row = 0; row < _mapSize; row++)
                    for (int column = 0; column < _mapSize; column++)
                    {
                        flashesCount += CheckOctopus(row, column);
                    }
            }

            return flashesCount;
        }

        private static void ReadData(string[] input)
        {
            for (int i = 0; i < _mapSize; i++)
                for (int j = 0; j < _mapSize; j++)
                {
                    _map[i, j] = (int)char.GetNumericValue(input[i][j]);
                }
        }

        private static int CheckOctopus(int row, int column)
        {
            if (_map[row, column] <= 9 || _map[row, column] == 0)
            {
                return 0;
            }

            _map[row, column] = 0;
            int flashesCount = 1;

            for (int i = row - 1; i <= row + 1; i++)
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if ((i == row && j == column) || i < 0 || i >= _mapSize ||
                        j < 0 || j >= _mapSize || _map[i, j] == 0)
                        continue;

                    _map[i, j]++;
                    flashesCount += CheckOctopus(i, j);
                }

            return flashesCount;
        }
    }

    public static class DumboOctopus2
    {
        private const int _mapSize = 10;
        private static int[,] _map = new int[_mapSize, _mapSize];

        public static int GetFirstAllTogetherFlash(string[] input)
        {
            ReadData(input);

            for (int step = 1; ; step++)
            {
                for (int row = 0; row < _mapSize; row++)
                    for (int column = 0; column < _mapSize; column++)
                    {
                        _map[row, column] += 1;
                    }

                int flashesCount = 0;
                for (int row = 0; row < _mapSize; row++)
                    for (int column = 0; column < _mapSize; column++)
                    {
                        flashesCount += CheckOctopus(row, column);
                    }

                if (flashesCount == 100)
                    return step;
            }
        }

        private static void ReadData(string[] input)
        {
            for (int i = 0; i < _mapSize; i++)
                for (int j = 0; j < _mapSize; j++)
                {
                    _map[i, j] = (int)char.GetNumericValue(input[i][j]);
                }
        }

        private static int CheckOctopus(int row, int column)
        {
            if (_map[row, column] <= 9 || _map[row, column] == 0)
            {
                return 0;
            }

            _map[row, column] = 0;
            int flashesCount = 1;

            for (int r = row - 1; r <= row + 1; r++)
                for (int c = column - 1; c <= column + 1; c++)
                {
                    if ((r == row && c == column) || r < 0 || r >= _mapSize ||
                        c < 0 || c >= _mapSize || _map[r, c] == 0)
                        continue;

                    _map[r, c]++;
                    flashesCount += CheckOctopus(r, c);
                }

            return flashesCount;
        }
    }
}

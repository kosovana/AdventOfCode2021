using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class SyntaxScoring
    {
        private static Dictionary<char, int> _closingCharsRating = new Dictionary<char, int>
        {
            {')', 3},
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };

        private static Dictionary<char, char> _characters = new Dictionary<char, char>
        { {')', '('},
          {']', '['},
          {'}', '{'},
          {'>', '<'}
        };

        public static int GetErrorScore(string[] input)
        {
            int totalScore = 0;
            foreach (var line in input)
            {
                Stack<char> notProcessedChars = new Stack<char>();
                foreach (char character in line)
                {
                    if (_closingCharsRating.Keys.Contains(character))
                    {
                        char prevChar = notProcessedChars.Pop();
                        if (prevChar != _characters[character])
                        {
                            totalScore += _closingCharsRating[character];
                            break;
                        }
                    }
                    else
                    {
                        notProcessedChars.Push(character);
                    }
                }
            }

            return totalScore;
        }
    }

    public class SyntaxScoring2
    {
        private static Dictionary<char, int> _closingCharsRating = new Dictionary<char, int>
        {
            {')', 1},
            {']', 2},
            {'}', 3},
            {'>', 4}
        };

        private static Dictionary<char, char> _closingCharsMap = new Dictionary<char, char>
        { {')', '('},
          {']', '['},
          {'}', '{'},
          {'>', '<'}
        };

        private static Dictionary<char, char> _openingCharsMap = new Dictionary<char, char>
        { {'(', ')'},
          {'[', ']'},
          {'{', '}'},
          {'<', '>'}
        };

        public static long GetIncompleteLinesScore(string[] input)
        {
            List<long> subTotalScores = new List<long>();
            foreach (var line in input)
            {
                Stack<char> notProcessedChars = new Stack<char>();
                bool corruptedLine = false;
                foreach (char character in line)
                {
                    if (_closingCharsRating.Keys.Contains(character))
                    {
                        char prevChar = notProcessedChars.Pop();
                        if (prevChar != _closingCharsMap[character])
                        {
                            corruptedLine = true;
                            break;
                        }
                    }
                    else
                    {
                        notProcessedChars.Push(character);
                    }
                }

                if (corruptedLine)
                    continue;

                long subtotalScore = 0;
                foreach (var character in notProcessedChars)
                {
                    subtotalScore = 5 * subtotalScore + _closingCharsRating[_openingCharsMap[character]];
                }

                subTotalScores.Add(subtotalScore);
            }

            subTotalScores.Sort();
            return subTotalScores[subTotalScores.Count / 2];
        }
    }
}

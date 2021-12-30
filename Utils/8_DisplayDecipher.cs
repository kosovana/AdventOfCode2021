using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class DisplayDecipher
    {
        public static int GetNumberOfAppearanceTimes(string[] input)
        {
            var outputlines = input.Select(x => x.Substring(x.IndexOf('|') + 1));

            int[] numbers = new int[10];

            foreach (var line in outputlines)
            {
                var lineOfNumbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var number in lineOfNumbers)
                {
                    switch (number.Length)
                    {
                        case 2:
                            numbers[2]++;
                            break;
                        case 3:
                            numbers[7]++;
                            break;
                        case 4:
                            numbers[4]++;
                            break;
                        case 7:
                            numbers[8]++;
                            break;
                    }
                }
            }

            return numbers.Sum();
        }
    }

    public class DisplayDecipher2
    {
        public static int GetSumOfNumbers(string[] input)
        {
            List<Display> displays = new List<Display>(200);
            foreach (var line in input)
            {
                displays.Add(new Display(line));
            }

            int result = 0;
            foreach (var display in displays)
            {
                result += display.GetNumber();
            }

            return result;
        }

        public class Display
        {
            private Dictionary<int, string> _patterns = new Dictionary<int, string>(4);
            private List<string> _fiveSegmentNumbers = new List<string>(3);
            private List<string> _sixSegmentNumbers = new List<string>(3);
            private List<string> _outputNumbers = new List<string>(4);

            private Dictionary<int, int> _lengthToNumber = new Dictionary<int, int>
            {
                {2, 1 },
                {3, 7 },
                {4, 4 },
                {7, 8 }
            };

            public Display(string input)
            {
                ReadInput(input);
            }

            private void ReadInput(string input)
            {
                var _brokenNumbers = input.Split('|');
                var outputNumbers = _brokenNumbers[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string number in outputNumbers)
                {
                    _outputNumbers.Add(SortString(number));
                }

                var patternNumbers = _brokenNumbers[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var number in patternNumbers)
                {
                    var num = SortString(number);
                    if (number.Length == 5)
                        _fiveSegmentNumbers.Add(num);
                    else if (number.Length == 6)
                        _sixSegmentNumbers.Add(num);
                    else
                        _patterns.Add(_lengthToNumber[number.Length], num);
                }
            }

            private string SortString(string stringToSort)
            {
                var numChars = stringToSort.ToCharArray();
                Array.Sort(numChars);
                return new string(numChars);
            }

            public int GetNumber()
            {
                var segmentTop = _patterns[7].Single(x => !_patterns[1].Contains(x));
                var centralAndLeftTop = _patterns[4].Where(x => !_patterns[1].Contains(x));
                char segmentRightTop = ' ';
                char segmentRightBottom = ' ';

                int ind = 0;
                while (_sixSegmentNumbers.Count != 1)
                {
                    var number = _sixSegmentNumbers[ind];
                    bool removeNumber = false;
                    if (number.Except(_patterns[1]).Count() == 5)
                    {
                        _patterns.Add(6, number);
                        for (int i = 0; i < 2; i++)
                        {
                            if (!number.Contains(_patterns[1][i]))
                            {
                                segmentRightTop = _patterns[1][i];
                                segmentRightBottom = _patterns[1].Single(x => x != segmentRightTop);
                                removeNumber = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var segment in centralAndLeftTop)
                        {
                            if (!number.Contains(segment))
                            {
                                _patterns.Add(0, number);
                                removeNumber = true;
                                break;
                            }
                        }
                    }

                    if (removeNumber)
                        _sixSegmentNumbers.Remove(number);
                    else
                        ind++;
                }

                _patterns[9] = _sixSegmentNumbers[0];

                foreach (var number in _fiveSegmentNumbers)
                {
                    if (number.Except(_patterns[1]).Count() == 3)
                    {
                        _patterns.Add(3, number);
                    }
                    else if (!number.Contains(segmentRightTop))
                    {
                        _patterns.Add(5, number);
                    }
                    else if (!number.Contains(segmentRightBottom))
                    {
                        _patterns.Add(2, number);
                    }
                }

                var result = "";

                foreach (var number in _outputNumbers)
                {
                    foreach (var pattern in _patterns)
                    {
                        if (number == pattern.Value)
                        {
                            result += pattern.Key;
                        }
                    }
                }

                return Convert.ToInt32(result);
            }
        }
    }
}

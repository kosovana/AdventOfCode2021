using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class Polymer
    {
        private static Dictionary<string, int> _pairs = new Dictionary<string, int>();
        private static Dictionary<string, char> _map = new Dictionary<string, char>();
        private static Dictionary<char, int> _letters = new Dictionary<char, int>();

        public static int GetElementsQuantityDiff(string[] input)
        {
            ReadData(input);

            for (int i = 0; i < 10; i++)
            {
                var pairsCopy = new Dictionary<string, int>(_pairs);
                foreach (var pair in pairsCopy)
                {
                    var pairKey = pair.Key;
                    var keyQuantity = pair.Value;
                    if (keyQuantity == 0)
                        continue;

                    string leftItem = pairKey[0].ToString();
                    string rightItem = pairKey[1].ToString();
                    char centerItem = _map[pairKey];
                    AddLetter(centerItem, keyQuantity);

                    _pairs[leftItem + centerItem] += keyQuantity;
                    _pairs[centerItem + rightItem] += keyQuantity;
                    _pairs[pairKey] -= keyQuantity;
                }
            }

            return _letters.Values.Max() - _letters.Values.Min();
        }

        private static void AddLetter(char centerItem, int quantity)
        {
            if (_letters.ContainsKey(centerItem))
                _letters[centerItem] += quantity;
            else
                _letters.Add(centerItem, quantity);
        }

        private static void ReadData(string[] input)
        {
            var template = input[0];

            for (int i = 2; i < input.Length; i++)
            {
                var lineParts = input[i].Split(new[] { " -> " }, StringSplitOptions.None);
                _map.Add(lineParts[0], char.Parse(lineParts[1]));

                _pairs.Add(lineParts[0], 0);
            }

            for (int i = 0; i < template.Length - 1; i++)
            {
                AddLetter(template[i], 1);
                string pair = template.Substring(i, 2);
                _pairs[pair]++;
            }

            AddLetter(template[template.Length - 1], 1);
        }
    }

    public class Polymer2
    {
        private static Dictionary<string, long> _pairs = new Dictionary<string, long>();
        private static Dictionary<string, char> _map = new Dictionary<string, char>();
        private static Dictionary<char, long> _letters = new Dictionary<char, long>();

        public static long GetElementsQuantityDiff(string[] input)
        {
            ReadData(input);

            for (int i = 0; i < 40; i++)
            {
                var pairsCopy = new Dictionary<string, long>(_pairs);
                foreach (var pair in pairsCopy)
                {
                    var pairKey = pair.Key;
                    var keyQuantity = pair.Value;
                    if (keyQuantity == 0)
                        continue;

                    string leftItem = pairKey[0].ToString();
                    string rightItem = pairKey[1].ToString();
                    char centerItem = _map[pairKey];
                    AddLetter(centerItem, keyQuantity);

                    _pairs[leftItem + centerItem] += keyQuantity;
                    _pairs[centerItem + rightItem] += keyQuantity;
                    _pairs[pairKey] -= keyQuantity;
                }
            }

            return _letters.Values.Max() - _letters.Values.Min();
        }

        private static void AddLetter(char centerItem, long quantity)
        {
            if (_letters.ContainsKey(centerItem))
                _letters[centerItem] += quantity;
            else
                _letters.Add(centerItem, quantity);
        }

        private static void ReadData(string[] input)
        {
            var template = input[0];

            for (int i = 2; i < input.Length; i++)
            {
                var lineParts = input[i].Split(new[] { " -> " }, StringSplitOptions.None);
                _map.Add(lineParts[0], char.Parse(lineParts[1]));

                _pairs.Add(lineParts[0], 0);
            }

            for (int i = 0; i < template.Length - 1; i++)
            {
                AddLetter(template[i], 1);
                string pair = template.Substring(i, 2);
                _pairs[pair]++;
            }

            AddLetter(template[template.Length - 1], 1);
        }
    }
}

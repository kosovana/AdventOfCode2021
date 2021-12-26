using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class PowerConsumption
    {
        public static int GetPowerConsumption(string[] input)
        {
            int oneCount = 0;
            int zeroCount = 0;
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < input[0].Length; i++)
            {
                foreach (var line in input)
                {
                    if (line[i] == '1')
                        oneCount += 1;
                    else
                        zeroCount += 1;
                }

                if (oneCount > zeroCount)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }

                oneCount = 0;
                zeroCount = 0;
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }
    }

    public class PowerConsumption2
    {
        public static int GetPowerConsumption(string[] input)
        {
            string oxygenRateing = "";
            string co2Rating = "";

            List<string> oxygenNumbers = input.ToList();
            List<string> co2Numbers = input.ToList();
            for (int i = 0; i < input[0].Length; i++)
            {
                if (string.IsNullOrEmpty(oxygenRateing))
                    oxygenNumbers = GetNumbersForOxygenRating(oxygenNumbers, i);
                if (string.IsNullOrEmpty(co2Rating))
                    co2Numbers = GetNumbersForCo2Rating(co2Numbers, i);

                if (oxygenNumbers.Count == 1)
                    oxygenRateing = oxygenNumbers[0];

                if (co2Numbers.Count == 1)
                    co2Rating = co2Numbers[0];
            }

            return Convert.ToInt32(oxygenRateing, 2) * Convert.ToInt32(co2Rating, 2);
        }

        private static List<string> GetNumbersForOxygenRating(List<string> numbers, int position)
        {
            int mostCommonBit = GetMostCommonBit(numbers, position, out List<string> ones, out List<string> zeros);

            if (mostCommonBit == 1 || mostCommonBit < 0)
                return ones;

            return zeros;
        }

        private static List<string> GetNumbersForCo2Rating(List<string> numbers, int position)
        {
            int mostCommonBit = GetMostCommonBit(numbers, position, out List<string> ones, out List<string> zeros);

            if (mostCommonBit == 1 || mostCommonBit < 0)
                return zeros;

            return ones;
        }

        private static int GetMostCommonBit(List<string> numbers, int position, out List<string> ones, out List<string> zeros)
        {
            ones = new List<string>();
            zeros = new List<string>();

            int oneCount = 0;
            int zeroCount = 0;
            foreach (var number in numbers)
            {
                if (number[position] == '1')
                {
                    oneCount += 1;
                    ones.Add(number);
                }
                else
                {
                    zeroCount += 1;
                    zeros.Add(number);
                }
            }

            if (oneCount > zeroCount)
                return 1;
            if (oneCount == zeroCount)
                return -1;
            return 0;
        }
    }
}

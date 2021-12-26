using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class HydroVenture
    {
        public static int GetOverlapingPointsCount(string[] input)
        {
            Dictionary<(int, int), int> points = new Dictionary<(int, int), int>();

            foreach (var line in input)
            {
                var lineEnds = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var firstXY = ConvertToIntXY(lineEnds[0]);
                var lastXY = ConvertToIntXY(lineEnds[1]);

                /*if (!(firstXY[0] == lastXY[0] || firstXY[1] == lastXY[1])) //this is for part 1
                    continue;*/

                int xIncrementor = GetIncrementor(firstXY[0], lastXY[0]);
                int yIncrementor = GetIncrementor(firstXY[1], lastXY[1]);

                int x = firstXY[0];
                int y = firstXY[1];

                var pointsCount = firstXY[0] != lastXY[0] ? Math.Abs(firstXY[0] - lastXY[0]) :
                                                            Math.Abs(firstXY[1] - lastXY[1]);
                for (int i = 0; i <= pointsCount; i++)
                {
                    if (points.ContainsKey((x, y)))
                        points[(x, y)]++;
                    else
                        points.Add((x, y), 1);

                    x += xIncrementor;
                    y += yIncrementor;
                }
            }

            int result = 0;
            foreach (var point in points)
            {
                if (point.Value > 1)
                    result++;
            }

            return result;
        }

        private static int GetIncrementor(int first, int last)
        {
            if (first > last)
                return -1;

            if (first < last)
                return 1;

            return 0;
        }

        private static int[] ConvertToIntXY(string stringXY)
        {
            return stringXY.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        }
    }
}

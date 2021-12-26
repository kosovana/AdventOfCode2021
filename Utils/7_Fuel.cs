using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
    public class Fuel
    {
        public static int GetFuelCost(string input)
        {
            List<int> locations = input.Split(',').Select(x => Convert.ToInt32(x)).OrderBy(x => x).ToList();

            var percent25 = Convert.ToInt32(locations.Count * 0.25m);

            var medianLocations = locations.Skip(percent25).Take(percent25 * 2).OrderBy(x => x).ToList();

            int minCost = int.MaxValue;
            foreach (var location in medianLocations)
            {
                int cost = CalculateFuelCost(location, locations);
                if (cost < minCost)
                {
                    minCost = cost;
                }
            }

            return minCost;
        }

        private static int CalculateFuelCost(int position, List<int> locations)
        {
            int fuelCost = 0;
            foreach (var location in locations)
            {
                int dif = Math.Abs(location - position);
                fuelCost += Convert.ToInt32((1 + dif) * 0.5m * dif);

                //fuelCost += Math.Abs(location - position); for the first part
            }

            return fuelCost;
        }
    }
}

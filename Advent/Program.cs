using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            var inputLines = File.ReadAllLines(filePath);

            Console.WriteLine(Fuel.GetFuelCost(inputLines[0]));

            //Console.WriteLine(Lanternfish2.LanternfishCount(inputLines[0], 256));
            //Console.WriteLine(HydroVenture.GetOverlapingPointsCount(inputLines));
            //Console.WriteLine(Bingo.Play(inputLines));
            //Console.WriteLine(PowerConsumption2.GetPowerConsumption(inputLines));
            //Console.WriteLine(PowerConsumption.GetPowerConsumption(inputLines));
            //Console.WriteLine(Location2.GetPosition(inputLines));
            //Console.WriteLine(DepthMeasurements.GetDepthIncreaseCount(inputLines.Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToList()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = Origami2.GetLetters(inputLines);

            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
            sw.Stop();

            //Console.WriteLine(result);
            Console.WriteLine(sw.ElapsedMilliseconds);

            //var result = Origami.GetDotsCount(inputLines);
            //var result = PassagePathing2.GetPathsCount(inputLines);
            //var result = PassagePathing.GetPathsCount(inputLines);
            //var result = DumboOctopus2.GetFirstAllTogetherFlash(inputLines);
            //var result = SyntaxScoring2.GetIncompleteLinesScore(inputLines);
            //int result = SyntaxScoring.GetErrorScore(inputLines);
            //int result = SmokeBasing2.GetLagestBasins(inputLines);
            //int result = DisplayDecipher2.GetSumOfNumbers(inputLines);
            //Console.WriteLine(DisplayDecipher.GetNumberOfAppearanceTimes(inputLines));
            //Console.WriteLine(Fuel.GetFuelCost(inputLines[0]));
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class SmokeBasingTests
    {
        private string input =
@"
2199943210
3987894921
9856789892
8767896789
9899965678";

        [TestMethod]
        public void GetLowerstPointsRiskTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int result = SmokeBasing.GetLowerstPointsRisk(inputLines);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void GetBasinSquareTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int result = SmokeBasing2.GetLagestBasins(inputLines);

            Assert.AreEqual(1134, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class ChitonTests
    {
        private string input =
@"
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

        [TestMethod]
        public void GetLowestTotalRiskTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = Chiton.GetLowestTotalRisk(inputLines);

            Assert.AreEqual(40, result);
        }
    }
}

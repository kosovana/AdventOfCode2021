using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class HydroVentureTests
    {
        private string input =
@"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        [TestMethod]
        public void GetOverlapingPointsCount()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = HydroVenture.GetOverlapingPointsCount(inputLines);

            //Assert.AreEqual(5, result); //for part 1
            Assert.AreEqual(12, result);
        }
    }
}

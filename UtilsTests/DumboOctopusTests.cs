using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class DumboOctopusTests
    {
        private string input =
@"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        [TestMethod]
        public void GetTotalFlashesTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = DumboOctopus.GetTotalFlashes(inputLines);

            Assert.AreEqual(1656, result);
        }

        [TestMethod]
        public void GetFirstAllTogetherFlashTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = DumboOctopus2.GetFirstAllTogetherFlash(inputLines);

            Assert.AreEqual(195, result);
        }
    }
}

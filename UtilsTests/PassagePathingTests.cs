using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class PassagePathingTests
    {
        private string input =
@"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

        [TestMethod]
        public void GetPathsCountTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = PassagePathing.GetPathsCount(inputLines);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void GetPathsCountTest_Part2()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var result = PassagePathing2.GetPathsCount(inputLines);

            Assert.AreEqual(36, result);
        }
    }
}

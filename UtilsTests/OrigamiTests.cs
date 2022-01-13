using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class OrigamiTests
    {
        string input =
@"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

        [TestMethod]
        public void GetDotsCountTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var result = Origami.GetDotsCount(inputLines);

            Assert.AreEqual(17, result);
        }

        [TestMethod]
        public void GetDotsCountTest2()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var result = Origami2.GetLetters(inputLines);

            Assert.AreEqual("#####", result[0]);
            Assert.AreEqual("#   #", result[1]);
            Assert.AreEqual("#   #", result[2]);
            Assert.AreEqual("#   #", result[3]);
            Assert.AreEqual("#####", result[4]);
        }
    }
}

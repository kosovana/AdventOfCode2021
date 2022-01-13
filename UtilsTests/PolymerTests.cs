using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class PolymerTests
    {
        string input =
@"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

        [TestMethod]
        public void GetElementsQuantityDiffTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var result = Polymer.GetElementsQuantityDiff(inputLines);

            Assert.AreEqual(1588, result);
        }

        [TestMethod]
        public void GetElementsQuantityDiffTest2()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.None);

            var result = Polymer2.GetElementsQuantityDiff(inputLines);

            Assert.AreEqual(2188189693529, result);
        }
    }
}

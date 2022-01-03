using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class SyntaxScoringTests
    {
        private string input =
@"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

        [TestMethod]
        public void GetErrorScoreTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int result = SyntaxScoring.GetErrorScore(inputLines);

            Assert.AreEqual(26397, result);
        }

        [TestMethod]
        public void GetIncompleteLinesScoreTest()
        {
            string[] inputLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = SyntaxScoring2.GetIncompleteLinesScore(inputLines);

            Assert.AreEqual(288957, result);
        }
    }
}

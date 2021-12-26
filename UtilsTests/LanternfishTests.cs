using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class LanternfishTests
    {
        private string input = "3,4,3,1,2";

        [TestMethod]
        public void LanternfishCountTest()
        {
            int fishCount = Lanternfish.LanternfishCount(input, 80);

            Assert.AreEqual(5934, fishCount);
        }

        [TestMethod]
        public void Lanternfish2CountTest()
        {
            //int fishCount = Lanternfish2.LanternfishCount(input, 80);
            //Assert.AreEqual(5934, fishCount);

            
            var fishCount = Lanternfish2.LanternfishCount(input, 256);
            Assert.AreEqual(26984457539, fishCount);
            
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class PowerConsumptionTests
    {
        [TestMethod]
        public void GetPowerConsumptionTest()
        {
            string[] lines = new string[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            var result = PowerConsumption.GetPowerConsumption(lines);
            Assert.AreEqual(198, result);
        }

        [TestMethod]
        public void GetPowerConsumption2Test()
        {
            string[] lines = new string[]
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            var result = PowerConsumption2.GetPowerConsumption(lines);
            Assert.AreEqual(230, result);
        }
    }
}

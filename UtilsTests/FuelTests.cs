using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class FuelTests
    {
        private string input = "16,1,2,0,4,2,7,1,2,14";

        [TestMethod]
        public void GetFuelCostTest()
        {
            var result = Fuel.GetFuelCost(input);

            Assert.AreEqual(206, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class DepthMeasurementsTests
    {
        [TestMethod]
        public void GetDepthIncreaseCountTest()
        {
            List<int> measurements = new List<int>
            {
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263
            };

            var res = DepthMeasurements.GetDepthIncreaseCount(measurements);

            Assert.AreEqual(5, res);
        }
    }
}

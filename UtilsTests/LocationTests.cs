using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace UtilsTests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void GetPositionTest()
        {
            string[] lines = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            var result = Location2.GetPosition(lines);
            Assert.AreEqual(900, result);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containerschip;

namespace ContainerShipUnitTest
{
    [TestClass]
    public class UnitTestContainer
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Weight minimum is 4 tons")]
        public void ContainerWeightUnderMinWeight()
        {
            new Container(2, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Weight maximum is 30 tons")]
        public void ContainerWeightOverMaxWeight()
        {
            new Container(35, 1);
        }

        [TestMethod]
        public void ContainerValid()
        {
            Container container = new Container(10, 1);

            Assert.AreEqual(Container.ContainerTypes.Normal, container.ContainerType);
            Assert.IsTrue(container.Weight == 10);
        }
    }
}

using Containerschip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestsContainer
    {
        [TestMethod]
        public void ContainerWeightUnderMinWeight()
        {
            Exception exception = Assert.ThrowsException<Exception>(() => new Container(2, 1));
            Assert.AreEqual("Weight minimum is 4 tons", exception.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Weight maximum is 30 tons")]
        public void ContainerWeightOverMaxWeight()
        {
            Container container = new Container(35, 1);
        }

        [TestMethod]
        public void ContainerWeightValid()
        {
            Container container = new Container(10, 1);
            Assert.AreEqual(Container.ContainerTypes.Normal, container.ContainerType);
        }
    }
}
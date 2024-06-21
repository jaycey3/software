using Containerschip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContainerShipUnitTest
{
    [TestClass]
    public class UnitTestsCrane
    {
        [TestMethod]
        public void SortContainersTest()
        {
            Crane crane = new Crane(5, 3);

            crane.Containers = new List<Container>()
            {
                new Container(15, 1),
                new Container(10, 2),
                new Container(5, 3)
            };

            crane.Run();

            Assert.AreEqual(Container.ContainerTypes.Coolable, crane.Containers.First().ContainerType);
            Assert.AreEqual(Container.ContainerTypes.Valueable, crane.Containers.Skip(1).First().ContainerType);
            Assert.AreEqual(Container.ContainerTypes.Normal, crane.Containers.Last().ContainerType);
        }

        [TestMethod]
        public void RunContainersTooLight()
        {
            Crane crane = new Crane(5, 3);
            crane.Containers = new List<Container>
            {
                new Container(15, 1),
                new Container(10, 2),
                new Container(5, 3)
            };

            bool result = crane.Run();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RunShipIsCapsizing()
        {
            Crane crane = new Crane(2, 1);
            crane.Containers = new List<Container>
            {
                new Container(30, 1),
            };

            bool result = crane.Run();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RunSuccess()
        {
            Crane crane = new Crane(2, 1);
            crane.Containers = new List<Container>
            {
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 1),
                new Container(30, 2),
                new Container(30, 3)
            };

            bool result = crane.Run();

            Assert.IsTrue(result);
        }
    }
}
using Containerschip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContainerShipUnitTest
{
    [TestClass]
    public class UnitTestRow
    {
        [TestMethod]
        public void RowTryToAddContainerSuccess()
        {
            Row row = new Row(3, Row.Sides.Left);

            Container container1 = new Container(20, 1);
            Container container2 = new Container(15, 2);
            bool result1 = row.TryToAddContainerToRow(container1);
            bool result2 = row.TryToAddContainerToRow(container2);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void RowTryToAddContainerThreeValuablesInARow()
        {
            Row row = new Row(3, Row.Sides.Right);

            Container container1 = new Container(30, 2);
            Container container2 = new Container(30, 2);
            Container container3 = new Container(25, 2);

            bool result1 = row.TryToAddContainerToRow(container1);
            bool result2 = row.TryToAddContainerToRow(container2);
            bool result3 = row.TryToAddContainerToRow(container3);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

    }
}

using Containerschip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ContainerShipUnitTest
{
    [TestClass]
    public class UnitTestStack
    {
        [TestMethod]
        public void StackTryToAddContainerToEmptyStack()
        {
            Stack stack = new Stack(1);

            Container container = new Container(20, 1);
            bool result = stack.TryToAddContainerToStack(container);

            Assert.IsTrue(result);
            Assert.AreEqual(1, stack.Containers.Count);
            Assert.AreEqual(container, stack.Containers[0]);
        }

        [TestMethod]
        public void StackTryToAddContainerToFullStack()
        {
            Stack stack = new Stack(2);
            Container container = new Container(30, 1);

            for (int i = 0; i < 5; i++)
            {
                stack.TryToAddContainerToStack(container);
            }

            bool result = stack.TryToAddContainerToStack(container);

            Assert.IsTrue(stack.Containers.Count == 5);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TryToAddContainerToReservedStack()
        {
            Stack stack = new Stack(3);
            stack.Reserved = true;
            
            Container container = new Container(30, 1);
            bool result = stack.TryToAddContainerToStack(container);

            Assert.IsFalse(result);
            Assert.AreEqual(0, stack.Containers.Count);
        }

        [TestMethod]
        public void AddValuableContainerToStack()
        {
            Stack stack = new Stack(4);

            Container container = new Container(30, 1);
            bool result = stack.TryToAddContainerToStack(container);

            Container valuableContainer = new Container(25, 2);
            bool valuableResult = stack.TryToAddContainerToStack(valuableContainer);

            Assert.IsTrue(result);
            Assert.IsTrue(valuableResult);
            Assert.AreEqual(2, stack.Containers.Count);
            Assert.AreEqual(valuableContainer, stack.Containers[1]);
        }
    }
}

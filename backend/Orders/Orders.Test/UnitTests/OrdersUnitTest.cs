using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Orders.Test.UnitTests
{
    [TestClass]
    public class OrdersUnitTest
    {
        [TestMethod]
        public void ReceiveOrderAndProcessSuccessfully()
        {
        }

        [TestMethod]
        public void ReceiveOrderWithoutFoodId()
        {
        }

        [TestMethod]
        //[ExpectedException(typeof(ValidationException))]
        public void ReceiveOrderWithInvalidFoodId()
        {
        }

        [TestMethod]
        public void ReceiveOrderWithInvalidTimeOfDay()
        {
        }

        [TestMethod]
        public void ReceiveOrderWithNoData()
        {
        }
    }
}

using Microsoft.Extensions.Options;
using Orders.CustomExceptions;
using Orders.Domain;
using Orders.Model;
using Xunit;


namespace Orders.UnitTest
{
    public class OrdersUnitTest
    {
        private readonly APIOptions _apiOptions;
        public OrdersUnitTest()
        {
            string[] timeOfDays = { "morning", "night" };
            var apiOptions = Options.Create(new APIOptions() { AllowedTimeOfDays = timeOfDays });
            _apiOptions = apiOptions.Value;
        }

        [Fact]
        public void ReceiveOrderAndProcessSuccessfully_ReturnResponse()
        {
            var order = "morning,1,1,1";

            var controller = new OrderDomain(_apiOptions, order);
            controller.ValidateOrderDomain();
            var result = controller.ProcessOrder();

            Assert.Equal("eggs(x3)", result);
        }

        [Fact]
        public void ReceiveOrderWithoutFoodId_ReturnBlank()
        {
            var order = "morning";

            var controller = new OrderDomain(_apiOptions, order);
            controller.ValidateOrderDomain();
            var result = controller.ProcessOrder();

            Assert.Equal("", result);
        }

        [Fact]
        public void ReceiveOrderWithInvalidFoodId_ThrowsValidationException()
        {
            var order = "morning,A";

            var controller = new OrderDomain(_apiOptions, order);
            ValidationException ex = Assert.Throws<ValidationException>(() => controller.ValidateOrderDomain());

            Assert.Equal("Invalid Food Id", ex.Message);
        }

        [Fact]
        public void ReceiveOrderWithInvalidTimeOfDay_ThrowsValidationException()
        {
            var order = "evening,1,1,1";

            var controller = new OrderDomain(_apiOptions, order);
            ValidationException ex = Assert.Throws<ValidationException>(() => controller.ValidateOrderDomain());

            Assert.Equal("Invalid Time of Day", ex.Message);
        }

    }

}

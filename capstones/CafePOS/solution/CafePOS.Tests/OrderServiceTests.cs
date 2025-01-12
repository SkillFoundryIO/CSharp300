using CafePOS.Application.Services;
using CafePOS.Core.TimeOfDaySettings;
using CafePOS.Tests.Mocks.OrderRepo;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void IsValidOpenOrder_Fails_WhenOrderIsClosed()
        {
            var service = new OrderService(new ClosedOutOrder(), new Breakfast());

            var result = service.IsValidOpenOrder(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void IsValidOpenOrder_Fails_WhenInvalidOrderNumber()
        {
            var service = new OrderService(new InvalidOrderNumber(), new Breakfast());

            var result = service.IsValidOpenOrder(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void IsValidOpenOrder_Succeeds_WhenValidOrderExists()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.IsValidOpenOrder(5000);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void GetOpenOrders_Fails_WhenNoOpenOrdersExist()
        {
            var service = new OrderService(new ClosedOutOrder(), new Breakfast());

            var result = service.GetOpenOrders();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetOpenOrders_Succeeds_WhenValidOpenOrdersExist()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.GetOpenOrders();

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetCategories_Fails_WhenNoCategoriesExist()
        {
            var service = new OrderService(new MissingOrderCategoriesAndItems(), new Breakfast());

            var result = service.GetCategories();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetCategories_Succeeds_WhenCategoriesExist()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.GetCategories();

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(3));
        }

        [Test]
        public void GetAvailableItems_Fails_WhenNoItemsArePresent()
        {
            var service = new OrderService(new MissingOrderCategoriesAndItems(), new Breakfast());

            var result = service.GetAvailableItems(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetAvailableItems_Succeeds_WhenItemsArePresent()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.GetAvailableItems(5000);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetItem_Fails_WhenNoItemIsPresent()
        {
            var service = new OrderService(new MissingOrderCategoriesAndItems(), new Breakfast());

            var result = service.GetItem(5, 5);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetItem_Succeeds_WhenItemIsPresent()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.GetItem(5, 5);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void GetOrderDetails_Fails_WhenNoOrderDetailsAvailable()
        {
            var service = new OrderService(new MissingOrderCategoriesAndItems(), new Breakfast());

            var result = service.GetOrderDetails(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetOrderDetails_Succeeds_WhenOrderDetailsAvailable()
        {
            var service = new OrderService(new OpenValidOrder(), new Breakfast());

            var result = service.GetOrderDetails(5000);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(2));
        }
    }
}

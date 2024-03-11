using CafePOS.Application.Services;
using CafePOS.Tests.Mocks.PaymentRepo;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        [Test]
        public void OrderIsUnder15Items_Fails_WhenItHas20Items()
        {
            var service = new PaymentService(new OrderHasOver15Items());

            var result = service.OrderIsUnder15items(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void OrderHasItems_Fails_WhenItHasNoItems()
        {
            var service = new PaymentService(new OrderHasNoItems());

            var result = service.OrderHasItems(5000);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void OrderHasItems_Succeeds_WhenOrderHas5Items()
        {
            var service = new PaymentService(new OrderHas5Items());

            var result = service.OrderHasItems(5000);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void OrderIsUnder15Items_Succeeds_WhenOrderHas5Items()
        {
            var service = new PaymentService(new OrderHas5Items());

            var result = service.OrderIsUnder15items(5000);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void GetPaymentTypes_Fails_WhenSystemHasNoPaymentTypes()
        {
            var service = new PaymentService(new SystemHasNoPaymentTypes());

            var result = service.GetPaymentTypes();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetPaymentTypes_Succeeds_WhenPaymentTypesArePresent()
        {
            var service = new PaymentService(new OrderHasOver15Items());

            var result = service.GetPaymentTypes();

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(2));
        }

        [Test]
        public void ProcessPayment_Fails_WhenInvalidPaymentTypeSpecified()
        {
            var service = new PaymentService(new SystemHasNoPaymentTypes());

            var result = service.ProcessPayment(500, 2);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void ProcessPayment_Succeeds_WhenValidPaymentTypeSpecified()
        {
            var service = new PaymentService(new OrderHasOver15Items());

            var result = service.ProcessPayment(500, 2);

            Assert.That(result.Ok, Is.True);
        }

        [Test]
        public void GetOrderSubtotals_Fails_WhenOrderHasNoItems()
        {
            var service = new PaymentService(new OrderHasNoItems());

            var result = service.GetOrderSubtotals(500);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetOrderSubtotals_Succeeds_WhenOrderHasOver15Items()
        {
            var service = new PaymentService(new OrderHasOver15Items());

            var result = service.GetOrderSubtotals(500);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.SubTotal, Is.EqualTo(25));
            Assert.That(result.Data.Tax, Is.EqualTo(4));
            Assert.That(result.Data.Tip, Is.EqualTo(5));
        }

        [Test]
        public void AddTipToOrder_TipAdjusted_WhenOrderHasOver15Items()
        {
            var service = new PaymentService(new OrderHasOver15Items());

            var result = service.AddTipToOrder(500, 1);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Message, Is.EqualTo("Tip amount entered did not meet minimum. Tip was adjusted to 15%."));
        }

        [Test]
        public void AddTipToOrder_Succeeeds_WhenOrderHas5Items()
        {
            var service = new PaymentService(new OrderHas5Items());

            var result = service.AddTipToOrder(500, 1);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Message, Is.EqualTo("Tip amount has been applied to order."));
        }

        [Test]
        public void CanGetFinalTotal()
        {
            var service = new PaymentService(new OrderHas5Items());

            var result = service.GetFinalTotal(500);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data, Is.EqualTo(50));

        }
    }
}

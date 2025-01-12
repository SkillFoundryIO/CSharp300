using CafePOS.Application.Services;
using CafePOS.Core.Entities;
using CafePOS.Tests.MockRepos.ServerRepo;
using NUnit.Framework;

namespace CafePOS.Tests
{
    [TestFixture]
    public class NewOrderServiceTests
    {
        [Test]
        public void GetServerList_Fails_WhenNoServersAvailable()
        {
            var service = new NewOrderService(new NoServersAvailable());

            var result = service.GetServerList();

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetServerList_Succeeeds_WhenServerAvailable()
        {
            var service = new NewOrderService(new ServerAvailable());

            var result = service.GetServerList();

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetServer_Fails_WhenNoServersAvailable()
        {
            var service = new NewOrderService(new NoServersAvailable());

            var result = service.GetServer(1);

            Assert.That(result.Ok, Is.False);
        }

        [Test]
        public void GetServer_Succeeds_WhenServerAvailable()
        {
            var service = new NewOrderService(new ServerAvailable());

            var result = service.GetServer(1);

            Assert.That(result.Ok, Is.True);
            Assert.That(result.Data, Is.Not.Null);
        }

        [Test]
        public void CanCreateOrder()
        {
            var service = new NewOrderService(new ServerAvailable());

            var result = service.CreateNewOrder(new Server());

            Assert.That(result.Ok, Is.True);
        }
    }
}

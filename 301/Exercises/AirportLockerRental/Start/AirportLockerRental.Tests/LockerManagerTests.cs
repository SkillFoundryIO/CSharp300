using NUnit.Framework;
using AirportLockerRental.UI.Actions;
using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.Tests
{
    public class LockerManagerTests
    {
        private LockerManager GetLockerManager()
        {
            return new LockerManager();
        }

        private LockerContents GetLockerContents()
        {
            return new LockerContents()
            {
                RenterName = "Ima Renter",
                Description = "Things and stuffs."
            };
        }

        [Test]
        public void TestViewLocker_ValidNumber()
        {
            var lockerManager = GetLockerManager();
            var contents = GetLockerContents();

            lockerManager.RentLocker(1, contents);

            var result = lockerManager.ViewLocker(1);

            Assert.That(contents, Is.EqualTo(result));
        }

        [Test]
        public void TestCanRentLocker_Empty()
        {
            var lockerManager = GetLockerManager();
            bool result = lockerManager.CanRentLocker(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void TestCanRentLocker_Filled()
        {
            var lockerManager = GetLockerManager();
            var contents = GetLockerContents();

            lockerManager.RentLocker(1, contents);

            bool result = lockerManager.CanRentLocker(1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TestRentLocker_Success()
        {
            var lockerManager = GetLockerManager();
            var contents = GetLockerContents();

            bool result = lockerManager.RentLocker(1, contents);

            Assert.That(result, Is.True);
            Assert.That(contents, Is.EqualTo(lockerManager.ViewLocker(1)));
        }

        [Test]
        public void TestRentLocker_Failure()
        {
            var lockerManager = GetLockerManager();
            var contents1 = GetLockerContents();
            var contents2 = GetLockerContents();

            lockerManager.RentLocker(1, contents1);

            bool result = lockerManager.RentLocker(1, contents2);

            Assert.That(result, Is.False);
            Assert.That(contents1, Is.EqualTo(lockerManager.ViewLocker(1)));
        }

        [Test]
        public void TestEndRental_Success()
        {
            var lockerManager = GetLockerManager();
            var contents = GetLockerContents();

            lockerManager.RentLocker(1, contents);

            LockerContents result = lockerManager.EndRental(1);

            Assert.That(contents, Is.EqualTo(result));
            Assert.That(lockerManager.CanRentLocker(1), Is.True);
        }

        [Test]
        public void TestEndRental_Failure()
        {
            var lockerManager = GetLockerManager();
            LockerContents result = lockerManager.EndRental(1);

            Assert.That(result, Is.Null);
        }
    }
}
using AirportLockerRental.UI.DTOs;
using AirportLockerRental.UI.Storage;
using NUnit.Framework;

namespace AirportLockerRental.Tests
{
    public class ArrayLockerRepositoryTests
    {
        private ILockerRepository _repo;

        [SetUp]
        public void Initialize()
        {
            _repo = new ArrayLockerRepository(10);

            // add a few sample records
            _repo.Add(new LockerContents
            {
                LockerNumber = 1,
                RenterName = "Testy Tester",
                Description = "Things and Stuff"
            });

            _repo.Add(new LockerContents
            {
                LockerNumber = 7,
                RenterName = "Data Sampler",
                Description = "Bits & Bytes"
            });
        }

        [Test]
        public void CanGetContents()
        {
            Assert.That(_repo.Get(1), Is.Not.Null);
        }

        [Test]
        public void EmptyLockerReturnsNull()
        {
            Assert.That(_repo.Get(4), Is.Null);
        }

        [Test]
        public void AvailabilityCheck()
        {
            Assert.That(_repo.IsAvailable(4), Is.True);

            Assert.That(_repo.IsAvailable(1), Is.False);
        }

        [Test]
        public void CannotAddOutOfRange()
        {
            Assert.That(_repo.Add(new LockerContents
            {
                LockerNumber = 20,
                RenterName = "Baddy McOverflowFace",
                Description = "Forbidden items"
            }), Is.False);
        }

        [Test]
        public void CannotAddOccupied()
        {
            Assert.That(_repo.Add(new LockerContents
            {
                LockerNumber = 1,
                RenterName = "Baddy McUnavailableFace",
                Description = "Forbidden items"
            }), Is.False);
        }

        [Test]
        public void CanRemoveItem()
        {
            Assert.That(_repo.Remove(7), Is.Not.Null);
        }

        [Test]
        public void RemoveEmptyReturnsNull()
        {
            Assert.That(_repo.Remove(10), Is.Null);
        }
    }
}

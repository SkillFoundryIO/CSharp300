using AirportLockerRental.UI.DTOs;
using AirportLockerRental.UI.Storage;
using NUnit.Framework;

namespace AirportLockerRental.Tests
{
    public class DictionaryLockerRepositoryTests
    {
        private ILockerRepository _repo;

        [SetUp]
        public void Initialize()
        {
            _repo = new DictionaryLockerRepository(10);

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
            Assert.IsNotNull(_repo.Get(1));
        }

        [Test]
        public void EmptyLockerReturnsNull()
        {
            Assert.IsNull(_repo.Get(4));
        }

        [Test]
        public void AvailabilityCheck()
        {
            Assert.IsTrue(_repo.IsAvailable(4));

            Assert.IsFalse(_repo.IsAvailable(1));
        }

        [Test]
        public void CannotAddOverCapacity()
        {
            var small = new DictionaryLockerRepository(1);

            Assert.IsTrue(small.Add(new LockerContents
            {
                LockerNumber = 1,
                RenterName = "Testy Tester",
                Description = "Things and Stuff"
            }));

            Assert.IsFalse(small.Add(new LockerContents
            {
                LockerNumber = 2,
                RenterName = "Stacked Overflow",
                Description = "Too many things"
            }));
        }

        [Test]
        public void CannotAddOccupied()
        {
            Assert.IsFalse(_repo.Add(new LockerContents
            {
                LockerNumber = 1,
                RenterName = "Baddy McUnavailableFace",
                Description = "Forbidden items"
            }));
        }

        [Test]
        public void CanRemoveItem()
        {
            Assert.IsNotNull(_repo.Remove(7));
        }

        [Test]
        public void RemoveEmptyReturnsNull()
        {
            Assert.IsNull(_repo.Remove(10));
        }
    }
}

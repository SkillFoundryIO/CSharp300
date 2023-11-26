using NUnit.Framework;

namespace LINQPracticeMinis.Tests
{
    [TestFixture]
    public class QueryTests
    {
        private LINQPractice _queries;

        [SetUp]
        public void Init()
        {
            var repository = new DataRepository(@"data\luchadores.csv");
            var luchadores = repository.Load();

            _queries = new LINQPractice(luchadores);
        }

        [Test]
        public void TestGetLuchadoresWithoutChampionships()
        {
            var result = _queries.GetLuchadoresWithoutChampionships();

            string[] expected = { "El Cacto", "La Rosa", "The Anvil", "The Hurricane",
                "El Toro", "Rapid Thunder", "Silver Sword", "Twisting Tornado", "Iron Claw",
                "The Panther", "Invisible Phantom", "Quick Lizard", "Golden Comet", "Daring Hornet",
                "Thunder Strike", "The Cobra", "Blazing Phoenix", "Stealthy Jaguar"
            };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetMexicanLuchadores()
        {
            var result = _queries.GetMexicanLuchadores();


            string[] expected = { "El Cacto", "The Anvil", "Furious Tiger", "El Toro", "Silver Sword",
                "Masked Eagle", "Invisible Phantom", "Daring Hornet", "Swift Puma"
            };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostWins()
        {
            var result = _queries.GetLuchadorWithMostWins();


            Assert.AreEqual("Thunder Strike", result.Alias);
        }

        [Test]
        public void TestGetAverageWeight()
        {
            var result = _queries.GetAverageWeight();

            Assert.AreEqual(74.44M, result);
        }

        [Test]
        public void TestGetTotalWinsByUSALuchadores()
        {
            var result = _queries.GetTotalWinsByUSALuchadores();

            Assert.AreEqual(213, result);
        }

        [Test]
        public void TestGetYoungestLuchador()
        {
            var result = _queries.GetYoungestLuchador();

            Assert.AreEqual("Rapid Thunder", result.Alias);
        }

        [Test]
        public void TestGetTallChampionLuchadores()
        {
            var result = _queries.GetTallChampionLuchadores();

            string[] expected = { "Mighty Serpent", "Whirlwind Leopard", "Furious Tiger" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorsMoreAverageDraws()
        {
            var result = _queries.GetLuchadorsMoreAverageDraws();

            string[] expected = { "Furious Tiger", "Quick Lizard", "Rapid Thunder", "Stealthy Jaguar",
                "El Cacto", "Invisible Phantom", "Crimson Wolf", "The Cobra", "Iron Claw", "Blazing Phoenix",
                "Flying Falcon"
            };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetTotalChampionshipsBySpanishLuchadores()
        {
            var result = _queries.GetTotalChampionshipsBySpanishLuchadores();

            Assert.AreEqual(4, result);
        }

        [Test]
        public void TestGetOldestMexicanLuchador()
        {
            var result = _queries.GetOldestMexicanLuchador();

            Assert.AreEqual("The Anvil", result.Alias);
        }

        [Test]
        public void TestGetSuccessfulLuchadores()
        {
            var result = _queries.GetSuccessfulLuchadores();

            string[] expected = { "Golden Comet", "Stealthy Jaguar" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithLowestWinToLossRatio()
        {
            var result = _queries.GetLuchadorWithLowestWinToLossRatio();

            Assert.AreEqual("Whirlwind Leopard", result);
        }

        [Test]
        public void TestGetAverageWinsByCountry()
        {
            var result = _queries.GetAverageWinsByCountry();

            Assert.AreEqual(29.78M, result["Mexico"]);
            Assert.AreEqual(26.12M, result["Spain"]);
            Assert.AreEqual(26.62M, result["USA"]);
        }

        [Test]
        public void TestGetLuchadoresWithTheInAlias()
        {
            var result = _queries.GetLuchadoresWithTheInAlias();

            string[] expected = { "The Anvil", "The Cobra", "The Hurricane", "The Panther" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostLossesAndAChampionship()
        {
            var result = _queries.GetLuchadorWithMostLossesAndAChampionship();

            Assert.AreEqual("Whirlwind Leopard", result.Alias);
        }

        [Test]
        public void TestGetTotalDrawsByLuchadoresWithoutChampionships()
        {
            var result = _queries.GetTotalDrawsByLuchadoresWithoutChampionships();

            Assert.AreEqual(26, result);
        }

        [Test]
        public void TestGetLuchadoresBornInThe90s()
        {
            var result = _queries.GetLuchadoresBornInThe90s();

            string[] expected = { "Stealthy Jaguar", "Flying Falcon", "Golden Comet", "Rapid Thunder",
                "Swift Puma", "Iron Claw", "Quick Lizard", "El Cacto", "Masked Eagle", "Crimson Wolf",
                "Mighty Serpent"
            };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.IsTrue(allExpectedPresent, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostMatches()
        {
            var result = _queries.GetLuchadorWithMostMatches();

            Assert.AreEqual("Thunder Strike", result);
        }

        [Test]
        public void TestGetCountryWithMostLuchadores()
        {
            var result = _queries.GetCountryWithMostLuchadores();

            Assert.AreEqual("Mexico", result);
        }

        [Test]
        public void TestGetLuchadorWithLongestAlias()
        {
            var result = _queries.GetLuchadorWithLongestAlias();

            Assert.AreEqual("Whirlwind Leopard", result.Alias);
        }
    }
}

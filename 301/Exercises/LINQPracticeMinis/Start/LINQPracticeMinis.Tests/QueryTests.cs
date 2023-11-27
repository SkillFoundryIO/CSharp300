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

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetMexicanLuchadores()
        {
            var result = _queries.GetMexicanLuchadores();


            string[] expected = { "El Cacto", "The Anvil", "Furious Tiger", "El Toro", "Silver Sword",
                "Masked Eagle", "Invisible Phantom", "Daring Hornet", "Swift Puma"
            };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostWins()
        {
            var result = _queries.GetLuchadorWithMostWins();


            Assert.That("Thunder Strike", Is.EqualTo(result.Alias));
        }

        [Test]
        public void TestGetAverageWeight()
        {
            var result = _queries.GetAverageWeight();

            Assert.That(74.44M, Is.EqualTo(result));
        }

        [Test]
        public void TestGetTotalWinsByUSALuchadores()
        {
            var result = _queries.GetTotalWinsByUSALuchadores();

            Assert.That(213, Is.EqualTo(result));
        }

        [Test]
        public void TestGetYoungestLuchador()
        {
            var result = _queries.GetYoungestLuchador();

            Assert.That("Rapid Thunder", Is.EqualTo(result.Alias));
        }

        [Test]
        public void TestGetTallChampionLuchadores()
        {
            var result = _queries.GetTallChampionLuchadores();

            string[] expected = { "Mighty Serpent", "Whirlwind Leopard", "Furious Tiger" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
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

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetTotalChampionshipsBySpanishLuchadores()
        {
            var result = _queries.GetTotalChampionshipsBySpanishLuchadores();

            Assert.That(4, Is.EqualTo(result));
        }

        [Test]
        public void TestGetOldestMexicanLuchador()
        {
            var result = _queries.GetOldestMexicanLuchador();

            Assert.That("The Anvil", Is.EqualTo(result.Alias));
        }

        [Test]
        public void TestGetSuccessfulLuchadores()
        {
            var result = _queries.GetSuccessfulLuchadores();

            string[] expected = { "Golden Comet", "Stealthy Jaguar" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithLowestWinToLossRatio()
        {
            var result = _queries.GetLuchadorWithLowestWinToLossRatio();

            Assert.That("Whirlwind Leopard", Is.EqualTo(result));
        }

        [Test]
        public void TestGetAverageWinsByCountry()
        {
            var result = _queries.GetAverageWinsByCountry();

            Assert.That(29.78M, Is.EqualTo(result["Mexico"]));
            Assert.That(26.12M, Is.EqualTo(result["Spain"]));
            Assert.That(26.62M, Is.EqualTo(result["USA"]));
        }

        [Test]
        public void TestGetLuchadoresWithTheInAlias()
        {
            var result = _queries.GetLuchadoresWithTheInAlias();

            string[] expected = { "The Anvil", "The Cobra", "The Hurricane", "The Panther" };

            var allExpectedPresent = expected.All(alias => result.Any(l => l.Alias == alias));

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostLossesAndAChampionship()
        {
            var result = _queries.GetLuchadorWithMostLossesAndAChampionship();

            Assert.That("Whirlwind Leopard", Is.EqualTo(result.Alias));
        }

        [Test]
        public void TestGetTotalDrawsByLuchadoresWithoutChampionships()
        {
            var result = _queries.GetTotalDrawsByLuchadoresWithoutChampionships();

            Assert.That(26, Is.EqualTo(result));
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

            Assert.That(allExpectedPresent, Is.True, "Not all expected aliases are present!");
        }

        [Test]
        public void TestGetLuchadorWithMostMatches()
        {
            var result = _queries.GetLuchadorWithMostMatches();

            Assert.That("Thunder Strike", Is.EqualTo(result));
        }

        [Test]
        public void TestGetCountryWithMostLuchadores()
        {
            var result = _queries.GetCountryWithMostLuchadores();

            Assert.That("Mexico", Is.EqualTo(result));
        }

        [Test]
        public void TestGetLuchadorWithLongestAlias()
        {
            var result = _queries.GetLuchadorWithLongestAlias();

            Assert.That("Whirlwind Leopard", Is.EqualTo(result.Alias));
        }
    }
}

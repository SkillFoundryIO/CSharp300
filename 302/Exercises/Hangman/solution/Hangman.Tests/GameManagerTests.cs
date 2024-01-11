using Hangman.BLL;
using NUnit.Framework;

namespace Hangman.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        private GameManager _gm;

        [SetUp]
        public void Init()
        {
            _gm = new GameManager("APPLE", 5);
        }

        [Test]
        public void SingleLetterGuess()
        {
            var response = _gm.Guess("A");

            Assert.That(response.Status, Is.EqualTo(GameStatus.CorrectGuess));
            Assert.That(response.TotalLettersGuessed, Is.EqualTo(1));
        }

        [Test]
        public void MultipleLetterGuess()
        {
            var response = _gm.Guess("P");

            Assert.That(response.Status, Is.EqualTo(GameStatus.CorrectGuess));
            Assert.That(response.TotalLettersGuessed, Is.EqualTo(2));
        }

        [Test]
        public void WinViaLetterGuesses()
        {
            _gm.Guess("A");
            _gm.Guess("P");
            _gm.Guess("L");
            var response = _gm.Guess("E");

            Assert.That(response.Status, Is.EqualTo(GameStatus.WinGame));
        }

        [Test]
        public void WinViaWordGuess()
        {
            var response = _gm.Guess("APPLE");

            Assert.That(response.Status, Is.EqualTo(GameStatus.WinGame));
        }

        [Test]
        public void LoseViaStrikes()
        {
            _gm.Guess("V");
            _gm.Guess("W");
            _gm.Guess("X");
            _gm.Guess("Y");
            var response = _gm.Guess("Z");

            Assert.That(response.Status, Is.EqualTo(GameStatus.LoseGame));
        }

        [Test]
        public void IncorrectLetter()
        {
            var response = _gm.Guess("Z");

            Assert.That(response.Status, Is.EqualTo(GameStatus.IncorrectGuess));
            Assert.That(_gm.StrikesRemaining, Is.EqualTo(4));
        }

        [Test]
        public void IncorrectWord()
        {
            var response = _gm.Guess("ZEBRA");

            Assert.That(response.Status, Is.EqualTo(GameStatus.IncorrectGuess));
            Assert.That(_gm.StrikesRemaining, Is.EqualTo(4));
        }
    }
}
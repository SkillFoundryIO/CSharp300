using Hangman.BLL;
using Hangman.BLL.Interfaces;

namespace Hangman.UI
{
    public class App
    {
        private IPlayer _player1;
        private IPlayer _player2;
        private bool _isPlayer1Turn;

        public App(IPlayer p1, IPlayer p2)
        {
            _player1 = p1;
            _player2 = p2;
            _isPlayer1Turn = true;
        }

        public void Run()
        {
            // application loop
            do
            {
                Console.Clear();
                IPlayer currentGuesser = _isPlayer1Turn ? _player1 : _player2;
                IPlayer currentWordSelector = !_isPlayer1Turn ? _player1 : _player2;

                Console.WriteLine($"{currentWordSelector.Name}, you will pick the first word to guess. {currentGuesser.Name}, look away!");

                GameManager gm = new GameManager(currentWordSelector.WordSource.GetWord(), 5);
                GuessResponse response;

                // game loop
                do
                {
                    Console.Clear();

                    Console.WriteLine($"Strikes Remaining: {gm.StrikesRemaining}");
                    Console.WriteLine($"Previous Guesses: { gm.PreviousGuesses}\n");
                    Console.WriteLine($"Word: {gm.Puzzle}\n");
                    response = gm.Guess(currentGuesser.GetGuess());

                    switch(response.Status)
                    {
                        case GameStatus.WinGame:
                            Console.WriteLine($"{currentGuesser.Name} guessed the word. They Win!");
                            currentGuesser.Wins++;
                            break;
                        case GameStatus.LoseGame:
                            Console.WriteLine("Sorry, that was not found!");
                            Console.WriteLine($"{currentGuesser.Name} has struck out, {currentWordSelector.Name} wins!");
                            currentWordSelector.Wins++;
                            break;
                        case GameStatus.DuplicateGuess:
                            Console.WriteLine("You already guessed that!");
                            break;
                        case GameStatus.CorrectGuess:
                            Console.WriteLine($"We found {response.TotalLettersGuessed} of those!");
                            break;
                        case GameStatus.IncorrectGuess:
                            Console.WriteLine("Sorry, that was not found!");
                            break;
                    }
                    ConsoleIO.AnyKey();
                } while (response.Status != GameStatus.LoseGame && response.Status != GameStatus.WinGame);

                // flip bool to start next player's turn
                _isPlayer1Turn = !_isPlayer1Turn;

                Console.WriteLine("The score is: ");
                Console.WriteLine($"{_player1.Name} - {_player1.Wins}");
                Console.WriteLine($"{_player2.Name} - {_player2.Wins}\n");
            } while (ConsoleIO.PlayAgain());          
        }
    }
}

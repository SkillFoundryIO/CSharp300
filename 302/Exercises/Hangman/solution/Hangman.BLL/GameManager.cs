namespace Hangman.BLL
{
    public class GameManager
    {
        private string _word;
        private List<string> _previousGuesses;
        private string[] _puzzle;
        private int _strikesRemaining; 

        public GameManager(string wordToGuess, int strikes)
        {
            _word = wordToGuess;
            _puzzle = new string[wordToGuess.Length];
            for(int i = 0; i < wordToGuess.Length; i++)
            {
                _puzzle[i] = "_";
            }      
            
            _strikesRemaining = strikes;
            _previousGuesses = new List<string>();
        }

        public string WordToGuess { get { return _word; } }
        public string Puzzle { get { return string.Join(" ", _puzzle); } }
        public int StrikesRemaining { get { return _strikesRemaining; } }
        public string PreviousGuesses { get { return string.Join(", ", _previousGuesses); } }

        public GuessResponse Guess(string guess)
        {
            GuessResponse response = new GuessResponse();

            if (_previousGuesses.Contains(guess))
            {
                response.Status = GameStatus.DuplicateGuess;
                return response;
            }

            _previousGuesses.Add(guess);
            
            // did they guess the word?
            if (guess.Length > 1)
            {
                ProcessWord(response, guess);
            }
            else
            {
                ProcessLetter(response, guess);
            }

            return response;
        }

        private void ProcessLetter(GuessResponse response, string guess)
        {
            int index = -1;
            int count = 0;

            do
            {
                index = _word.IndexOf(guess, index+1);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    count++;
                    _puzzle[index] = guess;
                }
            } while (true);

            // did they find any matches?
            if(count > 0)
            {
                response.TotalLettersGuessed = count;

                // did they guess all the letters?
                if (_puzzle.Any(c => c == "_"))
                {
                    response.Status = GameStatus.CorrectGuess;
                }
                else
                {
                    response.Status = GameStatus.WinGame;
                }                
            }
            else
            {
                ProcessWrongGuess(response);
            }    
        }

        private void ProcessWord(GuessResponse response, string guess)
        {
            if (guess == _word)
            {
                response.Status = GameStatus.WinGame;
            }
            else
            {
                ProcessWrongGuess(response);
            }
        }

        private void ProcessWrongGuess(GuessResponse response)
        {
            _strikesRemaining--;

            if(_strikesRemaining == 0)
            {
                response.Status = GameStatus.LoseGame;
            }
            else
            {
                response.Status = GameStatus.IncorrectGuess;
            }
        }
    }
}
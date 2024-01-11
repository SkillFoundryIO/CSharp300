namespace Hangman.BLL
{
    public class GuessResponse
    {
        public GameStatus Status { get; set; }
        public int? TotalLettersGuessed { get; set; }
    }

    public enum GameStatus
    {
        WinGame,
        LoseGame,
        IncorrectGuess,
        CorrectGuess,
        DuplicateGuess
    }
}
